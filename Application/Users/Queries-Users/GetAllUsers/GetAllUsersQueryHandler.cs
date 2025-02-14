using Application.Authors.Queries_Authors.GetAllAuthors;
using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries_Users.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, OperationResult<List<User>>>
    {
        private readonly ILogger<GetAllUsersQueryHandler> _logger;
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(ILogger<GetAllUsersQueryHandler> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }
        public async Task<OperationResult<List<User>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var users = await _userRepository.GetAllUsers();
                if(users == null || !users.Any())
                {
                    _logger.LogError("Users not found");
                    return OperationResult<List<User>>.Failure("No users found");
                }
                _logger.LogInformation("Users found");
                return OperationResult<List<User>>.Successfull(users.ToList(), "Users found");
            }
            catch
            {
                _logger.LogError("Users not found");
                return OperationResult<List<User>>.Failure("Users not found");
            }
        }
    }
}