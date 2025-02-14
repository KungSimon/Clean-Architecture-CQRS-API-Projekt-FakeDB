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
        public async Task<User> AddUser(User user)
        {
            _logger.LogInformation("Adding a new user: {Name}", user.UserName);
            _realDatabase.Users.Add(user);
            await _realDatabase.SaveChangesAsync();
            _logger.LogInformation("User added successfully: {Name}", user.UserName);
            return user;
        }

        public async Task<string> DeleteUser(Guid id)
        {
            _logger.LogInformation("Deleting user with Id: {UserId}", id);
            var user = await _realDatabase.Users.FindAsync(id);
            if (user != null)
            {
                _realDatabase.Users.Remove(user);
                await _realDatabase.SaveChangesAsync();
                _logger.LogInformation("User deleted successfully: {UserId}", id);
                return "User Deleted Successfully";
            }
            _logger.LogInformation("User not found: {UserId}", id);
            return "User Not Found";
        }

        public async Task<List<User>> GetAllUsers()
        {
            _logger.LogInformation("Retrieving all users");
            return await _realDatabase.Users.ToListAsync();
        }

        public async Task<User> LogInUser(User user)
        {
            _logger.LogInformation("Logging in user: {Username}", user.UserName);
            return await _realDatabase.Users.FirstOrDefaultAsync(u => u.UserName == user.UserName && u.Password == user.Password);
        }

        public async Task<User> GetUserById(Guid id)
        {
            _logger.LogInformation("Retrieving user with Id: {UserId}", id);
            return await _realDatabase.Users.FindAsync(id);
        }

        public async Task<User> UpdateUser(Guid id, User user)
        {
            _logger.LogInformation("Updating user with Id: {UserId}", id);
            _realDatabase.Users.Update(user);
            await _realDatabase.SaveChangesAsync();
            _logger.LogInformation("User updated successfully: {UserId}", id);
            return user;
        }

        public async Task<User> LogInUser(string username, string password)
        {
            _logger.LogInformation("Logging in user: {Username}", username);
            _realDatabase.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
            await _realDatabase.SaveChangesAsync();
            _logger.LogInformation("User logged in successfully: {Username}", username);
            return await _realDatabase.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        }
    }
}
