﻿using Application.Dtos;
using Application.Interfaces.RepositoryInterfaces;
using Application.Users.Queries_Users.LoginUsers.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly TokenHelper _tokenHelper;
        private readonly IPasswordService _passwordService;

        public LoginController(IUserRepository userRepository, TokenHelper tokenHelper, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
            _passwordService = passwordService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userRepository.GetByUsernameAsync(login.Username);
            if (user == null)
            {
                Console.WriteLine($"User not found: {login.Username}");
                return Unauthorized("Invalid username or password.");
            }

            Console.WriteLine($"User found: {user.Username}, PasswordHash: {user.PasswordHash}");

            if (!_passwordService.VerifyPassword(login.Password, user.PasswordHash))
            {
                Console.WriteLine($"Password verification failed for user: {login.Username}");
                return Unauthorized("Invalid username or password.");
            }

            var token = _tokenHelper.GenerateJwtToken(user.Username, "User");
            return Ok(new { token });
        }
    }
}
