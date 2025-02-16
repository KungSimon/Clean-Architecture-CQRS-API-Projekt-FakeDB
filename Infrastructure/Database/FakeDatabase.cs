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
        public List<Book> Books { get; set; } = new();
        public List<Author> Authors { get; set; } = new();
        public List<User> Users { get; set; } = new();
        public FakeDatabase()
        {
            Authors.AddRange(new List<Author>
        {
            new Author { Id = Guid.NewGuid(), Name = "J.K. Rowling" },
            new Author { Id = Guid.NewGuid(), Name = "George R.R. Martin" },
            new Author { Id = Guid.NewGuid(), Name = "J.R.R. Tolkien" }
        });

            Books.AddRange(new List<Book>
        {
            new Book { Id = Guid.NewGuid(), Title = "Harry Potter and the Sorcerer's Stone", AuthorId = Authors[0].Id},
            new Book { Id = Guid.NewGuid(), Title = "A Game of Thrones", AuthorId = Authors[1].Id },
            new Book { Id = Guid.NewGuid(), Title = "The Hobbit", AuthorId = Authors[2].Id}
        });
            Users.Add(new User
            {
                Id = Guid.NewGuid(),
                Email = "admin@example.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"),
            });
        }
    }
}

