using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Fisher.Bookstore.Models;
using Fisher.Bookstore.Api.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Fisher.Bookstore.Api.Data.BookstoreContext;

namespace Fisher.Bookstore.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookstoreContext>(options => 
        options.UseNpgsql(Configuration.GetConnectionString("BookstoreContext")));

            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", builder => {
                    builder.WithOrigins("https://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<BookstoreContext>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(option => {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwtOptions => 
            {
                jwtOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateActor = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = Configuration["JWTConfiguration:Issuer"],
                    ValidAudience = Configuration["JWTConfiguration:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWTConfiguration.Key"]))
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseMvc();

        }
    }
}