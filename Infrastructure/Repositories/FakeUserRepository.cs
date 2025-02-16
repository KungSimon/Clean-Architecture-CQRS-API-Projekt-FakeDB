using Application.Interfaces.RepositoryInterfaces;
using Domain;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        private readonly FakeDatabase _fakeDatabase;

        public FakeUserRepository(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public async Task AddUserAsync(User user)
        {
            if (_fakeDatabase.Users.Any(u => u.Username == user.Username || u.Email == user.Email))
            {
                return;
            }

            _fakeDatabase.Users.Add(user);
            await Task.CompletedTask;
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = _fakeDatabase.Users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _fakeDatabase.Users.Remove(user);
            }
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await Task.FromResult(_fakeDatabase.Users);
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            var user = _fakeDatabase.Users.FirstOrDefault(u => u.Username == username);
            return await Task.FromResult(user);
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await Task.FromResult(_fakeDatabase.Users.FirstOrDefault(u => u.Id == id));
        }

        public async Task<bool> IsUsernameOrEmailTakenAsync(string username, string email)
        {
            var isTaken = _fakeDatabase.Users.Any(u => u.Username == username || u.Email == email);
            return await Task.FromResult(isTaken);
        }


        public async Task UpdateUserAsync(User user)
        {
            var existingUser = _fakeDatabase.Users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Email = user.Email;
            }
            await Task.CompletedTask;
        }
    }
}
