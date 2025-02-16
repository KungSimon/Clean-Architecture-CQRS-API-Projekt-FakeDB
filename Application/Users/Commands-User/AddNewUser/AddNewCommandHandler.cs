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
        private readonly IPasswordService _passwordService;
        public AddNewUserCommandHandler(IUserRepository userRepository, ILogger<AddNewUserCommandHandler> logger, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _logger = logger;
            _passwordService = passwordService;
        }
        public async Task<OperationResult<User>> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var isTaken = await _userRepository.IsUsernameOrEmailTakenAsync(request.NewUser.Username, request.NewUser.Email);
                if (isTaken)
                {
                    _logger.LogWarning("Failed to add user. Username or email is already taken: {Username}, {Email}",
                        request.NewUser.Username, request.NewUser.Email);

                    return OperationResult<User>.Failure("Username or email is already taken.");
                }

                request.NewUser.PasswordHash = _passwordService.HashPassword(request.NewUser.PasswordHash);

                await _userRepository.AddUserAsync(request.NewUser);
                _logger.LogInformation("User added successfully: {Username}", request.NewUser.Username);

                return OperationResult<User>.Successfull(request.NewUser, "User added successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a user.");
                throw;
            }
        }
    }
}
