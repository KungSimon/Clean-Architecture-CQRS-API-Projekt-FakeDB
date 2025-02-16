using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.RepositoryInterfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(Guid id);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(Guid id);
        Task<User?> GetByUsernameAsync(string username);
        Task<bool> IsUsernameOrEmailTakenAsync(string username, string email);
    }
}
