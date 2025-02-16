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
    public class FakeAuthorRepository : IAuthorRepository
    {
        private readonly FakeDatabase _fakeDatabase;

        public FakeAuthorRepository(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task AddAuthorAsync(Author author)
        {
            var existingAuthor = _fakeDatabase.Authors.FirstOrDefault(a => a.Id == author.Id);
            if (existingAuthor != null)
            {
                existingAuthor.Name = author.Name;
            }
            else
            {
                _fakeDatabase.Authors.Add(author);
            }
            return Task.CompletedTask;
        }

        public Task DeleteAuthorAsync(Guid id)
        {
            var author = _fakeDatabase.Authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                _fakeDatabase.Authors.Remove(author);
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return Task.FromResult(_fakeDatabase.Authors.AsEnumerable());
        }

        public Task<Author> GetAuthorByIdAsync(Guid id)
        {
            return Task.FromResult(_fakeDatabase.Authors.FirstOrDefault(a => a.Id == id));
        }

        public Task UpdateAuthorAsync(Author author)
        {
            var authorToUpdate = _fakeDatabase.Authors.FirstOrDefault(existingAuthor => existingAuthor.Id == author.Id);
            if (authorToUpdate != null)
            {
                authorToUpdate.Name = author.Name;
                authorToUpdate.Id = author.Id;
                authorToUpdate.Bio = author.Bio;
            }
            return Task.CompletedTask;
        }
    }
}
