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
        Task AddBookAsync(Book book);
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(Guid id);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(Guid id);
    }
}
