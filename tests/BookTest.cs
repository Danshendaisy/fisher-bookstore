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
        [Fact]
        public void ChangeBookTitle()
        {
            var book2 = new Book()
            {
                Id = 2,
                Title = "Gone Girl",
                Author = new Author()
                {
                    Id = 34,
                    Name = "Gillian Flynn",
                    Bio = "A great author",
                },
                publishDate = DateTime.Now.AddMonths(-6),
                Publisher = "Crown Publishing"
            };
        //Act
        var newBookTitle = "Test Title";
        book2.ChangeBookTitle(newBookTitle);

        //Assert 
        var expectedTitle=newBookTitle;
        var actualTitle=book2.Title;
        Assert.Equal(expectedTitle,actualTitle);

        }
    
     [Fact]
        public void ChangePublisher()
        {
            var book3 = new Book()
            {
                Id = 2,
                Title = "Gone Girl",
                Author = new Author()
                {
                    Id = 34,
                    Name = "Gillian Flynn",
                    Bio = "A great author",
                },
                publishDate = DateTime.Now.AddMonths(-6),
                Publisher = "Crown Publishing"
            };
        //Act
        var newPublisher = "Columbis";
        book3.ChangePublisher(newPublisher);

        //Assert 
        var expectedPublisher=newPublisher;
        var actualPublisher=book3.Publisher;
        Assert.Equal(expectedPublisher,actualPublisher);

        }
    }
}
