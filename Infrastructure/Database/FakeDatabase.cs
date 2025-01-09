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
                new Book(Guid.NewGuid(), "SimonBook1", "SimonBook1"),
                new Book(Guid.NewGuid(), "SimonBook2", "Beskrivning2"),
                new Book(Guid.NewGuid(), "SimonBook3", "Beskrivning3"),
                new Book(Guid.NewGuid(), "SimonBook4", "Beskrivning4"),
                new Book(Guid.NewGuid(), "SimonBook5", "Beskrivning5"),
                new Book(Guid.NewGuid(), "SimonBook5", "Besk")
            };

        private static List<Author> allAuthorsFromDB = new List<Author>
            {
                new Author(Guid.NewGuid(), "Simon1", "AuthorBio1"),
                new Author(Guid.NewGuid(), "Simon2", "AuthorBio2"),
                new Author(Guid.NewGuid(), "Simon3", "AuthorBio3"),
                new Author(Guid.NewGuid(), "Simon4", "AuthorBio4"),
                new Author(Guid.NewGuid(), "Simon5", "AuthorBio5"),
                new Author(Guid.NewGuid(), "Simon6", "AuthorBio6"),
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
