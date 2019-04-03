using System;
using Xunit;
using Fisher.Bookstore.Bookstore.Models;

namespace tests
{
    public class BookTest
    {
        [Fact]
        public void ChangePublicationDate()
        {
            
            var book = new Book()
            {
                Id = 1,
                Title = "Domain Driven Design",
                Author = new Author()
                {
                    Id = 65,
                    Name = "Eric Evans"
                },
                publishDate = DateTime.Now.AddMonths(-6),
                Publisher = "McGraw-Hill"
            };
            //Act
            var newPublicationDate = DateTime.Now.AddMonths(2);
            book.ChangePublicationDate(newPublicationDate);

            //Assert
            var expectedPublicationDate = newPublicationDate.ToShortDateString();
            var actualPublicationDate=book.publishDate.ToShortDateString();
            Assert.Equal(expectedPublicationDate, actualPublicationDate);
            
        }
        
    }
}