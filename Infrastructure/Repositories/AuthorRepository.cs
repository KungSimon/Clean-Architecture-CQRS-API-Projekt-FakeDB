using Application.Interfaces.RepositoryInterfaces;
using Domain;
using Infrastructure.Database;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly RealDatabase _realDatabase;
        private readonly ILogger<AuthorRepository> _logger;

        public AuthorRepository(RealDatabase realDatabase, ILogger<AuthorRepository> logger)
        {
            _realDatabase = realDatabase;
            _logger = logger;
        }

        public async Task<Author> AddAuthorAsync(Author author)
        {
            _logger.LogInformation("Adding a new author: {Name}", author.Name);
            _realDatabase.Authors.Add(author);
            _realDatabase.SaveChanges();
            _logger.LogInformation("Author added successfully: {Name}", author.Name);
            return author;
        }

        public async Task<List<Author>> GetAllAuthorsAsync()
        {
            _logger.LogInformation("Retrieving all authors");
            return _realDatabase.Authors.ToList();
        }

        public async Task<Author> GetAuthorByIdAsync(Guid id)
        {
            _logger.LogInformation("Retrieving author with Id: {AuthorId}", id);
            return await _realDatabase.Authors.FindAsync(id);
        }

        public async Task<Author> UpdateAuthorAsync(Guid id, Author author)
        {
            _logger.LogInformation("Updating author with Id: {AuthorId}", id);
            _realDatabase.Authors.Update(author);
            _realDatabase.SaveChanges();
            _logger.LogInformation("Author updated successfully: {AuthorId}", id);
            return author;
        }

        public async Task<Author> DeleteAuthorAsync(Guid id)
        {
            _logger.LogInformation("Deleting author with Id: {AuthorId}", id);
            var author = await _realDatabase.Authors.FindAsync(id);
            if (author != null)
            {
                _realDatabase.Authors.Remove(author);
                await _realDatabase.SaveChangesAsync();
                _logger.LogInformation("Author deleted successfully: {AuthorId}", id);
                return author; // Return the deleted Author object
            }
            _logger.LogWarning("Author not found: {AuthorId}", id);
            return null;
        }
    }
}
