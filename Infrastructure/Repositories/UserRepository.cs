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
    public class UserRepository : IUserRepository
    {
        private readonly RealDatabase _realDatabase;
        private readonly ILogger<UserRepository> _logger;
        public UserRepository(RealDatabase realDatabase, ILogger<UserRepository> logger)
        {
            _realDatabase = realDatabase;
            _logger = logger;
        }

        public async Task AddUserAsync(User user)
        {
            await _realDatabase.Users.AddAsync(user);
            await _realDatabase.SaveChangesAsync();
            _logger.LogInformation("Adding a new user: {Name}", user.UserName);
            _realDatabase.Users.Add(user);
            await _realDatabase.SaveChangesAsync();
            _logger.LogInformation("User added successfully: {Name}", user.UserName);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            _logger.LogInformation("Retrieving all users");
            return await _realDatabase.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            _logger.LogInformation("Retrieving user with Id: {UserId}", id);
            return await _realDatabase.Users.FindAsync(id);
        }

        public async Task UpdateUserAsync(User user)
        {
            var existingUser = await _realDatabase.Users.FindAsync(user.Id);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Email = user.Email;
                existingUser.PasswordHash = user.PasswordHash;
                await _realDatabase.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(Guid id)
        {
            _logger.LogInformation("Deleting user with Id: {UserId}", id);
            var user = await _realDatabase.Users.FindAsync(id);
            if (user != null)
            {
                _realDatabase.Users.Remove(user);
                await _realDatabase.SaveChangesAsync();
                _logger.LogInformation("User deleted successfully: {UserId}", id);
            }
            _logger.LogInformation("User not found: {UserId}", id);
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _realDatabase.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<bool> IsUsernameOrEmailTakenAsync(string username, string email)
        {
            return await _realDatabase.Users.AnyAsync(u => u.Username == username || u.Email == email);
        }
    }
}
