//using Application.Interfaces.RepositoryInterfaces;
//using Application.Users.Queries_Users.LoginUsers.Helpers;
//using Domain;
//using MediatR;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Users.Queries_Users.LoginUsers
//{
//    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, OperationResult<string>>
//    {
//        private readonly ILogger<LoginUserQueryHandler> _logger;
//        private readonly IUserRepository _userRepository;
//        private readonly TokenHelper _tokenHelper;

//        public LoginUserQueryHandler( TokenHelper tokenHelper, ILogger<LoginUserQueryHandler> logger, IUserRepository userRepository)
//        {
//            _tokenHelper = tokenHelper;
//            _logger = logger;
//            _userRepository = userRepository;
//        }

//        public async Task<OperationResult<string>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
//        {
//            _logger.LogInformation("Trying to log in", request.LoginUser.UserName);

//            try
//            {
//                var user = await _userRepository.LogInUser(request.LoginUser.UserName, request.LoginUser.Password);

//                if (user == null)
//                {
//                    _logger.LogWarning("Invalid username or password", request.LoginUser.UserName);
//                    return OperationResult<string>.Failure("Invalid username or password");
//                }

//                string token = _tokenHelper.GenerateJwtToken(user);
//                _logger.LogInformation("User logged in successfully.", request.LoginUser.UserName);
//                return OperationResult<string>.Successfull(token);
//            }
//            catch (UnauthorizedAccessException e)
//            {
//                _logger.LogError(e, "An error occurred while logging in User", request.LoginUser.UserName);
//                return OperationResult<string>.Failure($"An error occurred while logging in: {e.Message}");
//            }
//        }
//    }
//}
