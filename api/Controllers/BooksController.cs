using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fisher.Bookstore.Models;
//using Fisher.Bookstore.Models;
using Fisher.Bookstore.Api.Data.BookstoreContext;
using Microsoft.AspNetCore.Mvc;



namespace Fisher.Bookstore.Api.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookstoreContext db;
        public BooksController(BookstoreContext db)
        {
            this.db = db;
            if (this.db.Books.Count() == 0)
            {
                this.db.Books.Add(new Book()
                {
                    Id = 1,
                    Title = "Design Patterns",
                    Author = "Erica Gamma",
                    ISBN = "978-0201633610"
                });
                this.db.Books.Add(new Book()
                {
                    Id = 2,
                    Title = "Continuous Delivery",
                    Author = "Jez Humble",
                    ISBN = "978-0321601919"
                });
                this.db.Books.Add(new Book()
                {
                    Id = 3,
                    Title = "The DevOps Handbook",
                    Author = "Gene Kim",
                    ISBN = "978-1942788003"
                });
            }
            this.db.SaveChanges();
        }
        // [HttpGet]
        // public IActionResult GetAction()
        // {
        //     return Ok(db.Books);
        // }
            // [HttpGet("{id}", Name = "GetBook")]
            // public IActionResult Get()
            // {
            //     return Ok(db.Books);
            //}
            [HttpGet("{id}", Name = "GetBook")]
            public IActionResult GetBook(int id)
            {
                var book = db.Books.FirstOrDefault(b => b.Id ==id);

                if (book == null)
                {
                    return NotFound();
                }
                return Ok(book);
            }

            [HttpPost]
            public IActionResult Post([FromBody]Book book)
            {
                if (book == null)
                {
                    return BadRequest();
                }
                
                db.Books.Add(book);
                db.SaveChanges();

                return CreatedAtRoute("GetBook", new {id = book.Id}, book);

            }
            
            [HttpPut("{id}")]
            public IActionResult Put (int id, [FromBody]Book book)
            {
                if(book == null || book.Id!=id)
                {
                    return BadRequest();
                }
                
                var bookToEdit = db.Books.FirstOrDefault(b => b.Id == id);
                if(bookToEdit == null)
                {
                    return NotFound();
                }

                bookToEdit.Title = book.Title;
                bookToEdit.ISBN = book.ISBN;

                db.Books.Update(bookToEdit);
                db.SaveChanges();

                return NoContent();
            }
            
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var book = db.Books.FirstOrDefault(b => b.Id == id);

                if(book == null)
                {
                    return NotFound();
                }
                db.Books.Remove(book);
                db.SaveChanges();
                
                return NoContent();
            }

        }
    }
