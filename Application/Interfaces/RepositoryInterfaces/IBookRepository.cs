using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.RepositoryInterfaces
{
    public interface IBookRepository
    {
        Task<Book> AddBookAsync(Book book);
        Task<List<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(Guid id);
        Task<Book> UpdateBookAsync(Book book);
        Task<string> DeleteBookAsync(Guid id);
    }
}
