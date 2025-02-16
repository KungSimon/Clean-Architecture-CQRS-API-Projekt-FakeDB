using Application.Interfaces.RepositoryInterfaces;
using Domain;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly RealDatabase _realDatabase;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(RealDatabase realDatabase, ILogger<BookRepository> logger)
        {
            _realDatabase = realDatabase;
            _logger = logger;
        }
        public async Task AddBookAsync(Book book)
        {
            _logger.LogInformation("Adding a new book: {Title}", book.Title);
            _realDatabase.Books.Add(book);
            await _realDatabase.SaveChangesAsync();
            _logger.LogInformation("Book added successfully: {Title}", book.Title);
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            _logger.LogInformation("Retrieving all books"); 
            return await _realDatabase.Books.ToListAsync();
        }


        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            _logger.LogInformation("Retrieving book with Id: {BookId}", id);
            return await _realDatabase.Books.FindAsync(id);
        }


        public async Task UpdateBookAsync(Book book)
        {
            _logger.LogInformation("Updating book with Id: {BookId}", book.Id);
            var existingBook = await _realDatabase.Books.FindAsync(book.Id);
            if(existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Description = book.Description;
                existingBook.AuthorId = book.AuthorId;

                _realDatabase.Books.Update(existingBook);
                await _realDatabase.SaveChangesAsync();
                _logger.LogInformation("Book updated successfully: {BookId}", book.Id);
            }
        }

        public async Task DeleteBookAsync(Guid id)
        {
            _logger.LogInformation("Deleting book with Id: {BookId}", id);
            var book = await _realDatabase.Books.FindAsync(id);
            if (book != null)
            {
                _realDatabase.Books.Remove(book);
                await _realDatabase.SaveChangesAsync();
                _logger.LogInformation("Book deleted successfully: {BookId}", id);
            }
            _logger.LogWarning("Book not found: {BookId}", id);
        }
    }
}
