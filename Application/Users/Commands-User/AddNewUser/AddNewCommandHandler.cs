using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands_User.AddNewUser
{
    public class AddNewUserCommandHandler : IRequestHandler<AddNewUserCommand, OperationResult <User>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<AddNewUserCommandHandler> _logger;
        public AddNewUserCommandHandler(IUserRepository userRepository, ILogger<AddNewUserCommandHandler> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }
        public async Task<OperationResult<User>> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.NewUser.UserName) ||
               string.IsNullOrEmpty(request.NewUser.Password))
            {
                return OperationResult<User>.Failure("First name and last name are required");
            }
            User userToCreate = new User
            {
                Id = Guid.NewGuid(),
                UserName = request.NewUser.UserName,
                Password = request.NewUser.Password
            };
            await _userRepository.AddUser(userToCreate);
            _logger.LogInformation("User Created");
            return OperationResult<User>.Successfull(userToCreate);
        }
    }
}
