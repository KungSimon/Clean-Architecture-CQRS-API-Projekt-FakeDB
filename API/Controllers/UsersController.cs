﻿using Application.Dtos;
using Application.Users.Commands_User.AddNewUser;
using Application.Users.Queries_Users.GetAllUsers;
using Application.Users.Queries_Users.LoginUsers;
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
        public async Task<IActionResult> Register([FromBody] UserDto newUser)
        {
            return Ok(await _mediator.Send(new AddNewUserCommand(newUser)));
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserDto userWantingToLogIn)
        {
            return Ok(await _mediator.Send(new LoginUserQuery(userWantingToLogIn)));
        }
    }
}