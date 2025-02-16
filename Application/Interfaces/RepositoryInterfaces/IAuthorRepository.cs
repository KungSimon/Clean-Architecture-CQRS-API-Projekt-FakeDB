using Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.RepositoryInterfaces
{
    public interface IAuthorRepository
    {
        Task AddAuthorAsync(Author author);
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(Guid id);
        Task UpdateAuthorAsync(Author author);
        Task DeleteAuthorAsync(Guid id);
    }
}
