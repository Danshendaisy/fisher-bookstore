using System;

namespace Fisher.Bookstore.Bookstore.Models
{
    public class Book
    {
        public int Id {get;set;}

        public string Title {get;set;}

        public string Author{get;set;}

        public string ISBN {get;set;}

        public DateTime publishDate{get;set;}
        public string Publisher{get;set;}

    }
}

