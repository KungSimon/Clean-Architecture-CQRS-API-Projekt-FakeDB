using Application.Interfaces.RepositoryInterfaces;
using Domain;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FakeBookRepository : IBookRepository
    {
        private readonly FakeDatabase _fakeDatabase;

        public FakeBookRepository(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task AddBookAsync(Book book)
        {
            _fakeDatabase.Books.Add(book);
            return Task.CompletedTask;
        }

        public Task DeleteBookAsync(Guid id)
        {
            var bookToDelete = _fakeDatabase.Books.FirstOrDefault(book => book.Id == id);
            if (bookToDelete != null) _fakeDatabase.Books.Remove(bookToDelete);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return Task.FromResult(_fakeDatabase.Books.AsEnumerable());
        }

        public Task<Book> GetBookByIdAsync(Guid id)
        {
            return Task.FromResult(_fakeDatabase.Books.FirstOrDefault(a => a.Id == id));
        }

        public Task UpdateBookAsync(Book book)
        {
            var bookToUpdate = _fakeDatabase.Books.FirstOrDefault(existingBook => existingBook.Id == book.Id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.AuthorId = book.AuthorId;
                bookToUpdate.Description = book.Description;
            }
            return Task.CompletedTask;
        }
    }
}
