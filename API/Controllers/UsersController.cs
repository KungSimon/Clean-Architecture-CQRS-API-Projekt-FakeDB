using Application.Dtos;
using Application.Dtos.UserDtos;
using Application.Users.Commands_User.AddNewUser;
using Application.Users.Queries_Users.GetAllUsers;
using Application.Users.Queries_Users.LoginUsers;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        internal readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery()));
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] User newUser)
        {
            return Ok(await _mediator.Send(new AddNewUserCommand(newUser)));
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] User userWantingToLogIn)
        {
            var userDto = new UserDto
            {
                UserName = userWantingToLogIn.UserName,
                Password = userWantingToLogIn.Password
                // Map other properties as needed
            };
            return Ok(await _mediator.Send(new LoginUserQuery(userDto)));
        }
    }
}
