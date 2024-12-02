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

        private static List<Book> allBooksFromDB = new List<Book>
        {
            new Book(1, "SimonBook1", "Beskrivning1"),
            new Book(2, "SimonBook2", "Beskrivning2"),
            new Book(3, "SimonBook3", "Beskrivning3"),
            new Book(4, "SimonBook4", "Beskrivning4"),
            new Book(5, "SimonBook5", "Beskrivning5"),
        };

        // 
        public Book AddNewBook(Book book)
        {
            allBooksFromDB.Add(book);
            return book;
        }

        public bool DeleteBook(int id)
        {
            var book = allBooksFromDB.FirstOrDefault(b => b.Id == id);
            if (book == null) return false;

            allBooksFromDB.Remove(book);
            return true;
        }

        public Book GetBookById(int id)
        {
            return allBooksFromDB.FirstOrDefault(b => b.Id == id);
        }

        public List<Book> GetAllBooks()
        {
            return allBooksFromDB;
        }

        public Book UpdateBook(int id, string title, string description)
        {
            var book = allBooksFromDB.FirstOrDefault(b => b.Id == id);
            if (book == null) return null;

            book.Title = title;
            book.Description = description;

            return book;
        }

        /// <summary>
        /// Books Above
        /// Authors Below
        /// </summary>

        public List<Author> Authors { get; set; } = new List<Author>
        {
            new Author(1, "Simon", "Lorem"),
            new Author(2, "Näslund", "Lorem")
        };

        public Author AddNewAuthor(Author author)
        {
            Authors.Add(author);
            return author;
        }

        public bool DeleteAuthor(int id)
        {
            var author = Authors.FirstOrDefault(a => a.Id == id);
            if (author == null) return false;

            Authors.Remove(author);
            return true;
        }

        public Author GetAuthorById(int id)
        {
            return Authors.FirstOrDefault(a => a.Id == id);
        }

        public List<Author> GetAllAuthors()
        {
            return Authors;
        }

        public Author UpdateAuthor(int id, Author author)
        {
            var authorToUpdate = Authors.FirstOrDefault(a => a.Id == id);
            if (authorToUpdate == null) return null;

            authorToUpdate.Name = author.Name;
            authorToUpdate.Bio = author.Bio;

            return authorToUpdate;
        }

        public List<User> Users
        {
            get { return allUsers; }
            set {  allUsers = value; }
        }

        private static List<User> allUsers = new()
        {
            new User {Id = Guid.NewGuid(), UserName = "Simon"},
            new User {Id = Guid.NewGuid(), UserName = "Näslund"},
            new User {Id = Guid.NewGuid(), UserName = "We"}
        };
    }

}
