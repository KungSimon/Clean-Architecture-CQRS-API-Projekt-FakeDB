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
        public async Task<Book> AddBookAsync(Book book)
        {
            _logger.LogInformation("Adding a new book: {Title}", book.Title);
            _realDatabase.Books.Add(book);
            await _realDatabase.SaveChangesAsync();
            _logger.LogInformation("Book added successfully: {Title}", book.Title);
            return book;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            _logger.LogInformation("Retrieving all books"); 
            return await _realDatabase.Books.ToListAsync();
        }


        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            _logger.LogInformation("Retrieving book with Id: {BookId}", id);
            return await _realDatabase.Books.FindAsync(id);
        }


        public async Task<Book> UpdateBookAsync(Book book)
        {
            _logger.LogInformation("Updating book with Id: {BookId}", book.Id);
            _realDatabase.Books.Update(book);
            await _realDatabase.SaveChangesAsync();
            _logger.LogInformation("Book updated successfully: {BookId}", book.Id);
            return book;
        }

        public async Task<string> DeleteBookAsync(Guid id)
        {
            _logger.LogInformation("Deleting book with Id: {BookId}", id);
            var book = await _realDatabase.Books.FindAsync(id);
            if (book != null)
            {
                _realDatabase.Books.Remove(book);
                await _realDatabase.SaveChangesAsync();
                _logger.LogInformation("Book deleted successfully: {BookId}", id);
                return "Book Deleted Successfully";
            }
            _logger.LogWarning("Book not found: {BookId}", id);
            return "Book Not Found";
        }
    }
}
