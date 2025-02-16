using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.RepositoryInterfaces
{
    public interface IAuthorRepository
    {
        Task<Author> AddAuthorAsync(Author author);

        Task<List<Author>> GetAllAuthorsAsync();

        Task<Author?> GetAuthorByIdAsync(Guid id);

        Task<Author> UpdateAuthorAsync(Guid id,Author author);

        Task<Author> DeleteAuthorAsync(Guid id);
    }
}
