using API.DTOs;
using Application.Dtos;
using Application.Interfaces.RepositoryInterfaces;
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
        private readonly IMediator _mediator;
        private readonly IPasswordService _passwordService;

        public UsersController(IMediator mediator, IPasswordService passwordService)
        {
            _mediator = mediator;
            _passwordService = passwordService;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] AddUserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = userDto.Username,
                Email = userDto.Email,
                PasswordHash = userDto.Password,
            };

            Console.WriteLine($"Registering user: {user.Username}, Email: {user.Email}, PasswordHash: {user.PasswordHash}");

            var command = new AddNewUserCommand(user);
            var result = await _mediator.Send(command);

            if (result.IsSuccessful)
            {
                return Ok(new { result.Message, UserId = result.Data.Id });
            }

            return BadRequest(result.Message);
        }
    }
}
