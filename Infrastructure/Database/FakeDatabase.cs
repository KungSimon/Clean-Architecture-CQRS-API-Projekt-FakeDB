using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class FakeDatabase
    {
        public List<Book> Books { get { return allBooksFromDB; } set { allBooksFromDB = value; } }
        public List<Author> Author { get { return allAuthorsFromDB; } set { allAuthorsFromDB = value; } }

        private static List<Book> allBooksFromDB = new List<Book>
            {
                new Book("SimonBook1"),
                new Book("SimonBook2"),
                new Book("SimonBook3"),
                new Book("SimonBook4"),
                new Book("SimonBook5"),
                new Book("SimonBook5")
            };

        private static List<Author> allAuthorsFromDB = new List<Author>
            {
                new Author("Simon1"),
                new Author("Simon2"),
                new Author("Simon3"),
                new Author("Simon4"),
                new Author("Simon5"),
                new Author("Simon6"),
            };

        public static List<User> Users
        {
            get { return allUsers; }
            set { allUsers = value; }
        }

        private static List<User> allUsers = new()
            {
                new User {Id = Guid.NewGuid(), UserName = "Simon"},
                new User {Id = Guid.NewGuid(), UserName = "Näslund"},
                new User {Id = Guid.NewGuid(), UserName = "We"}
            };
    }

}
