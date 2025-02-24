﻿using Application.Interfaces.RepositoryInterfaces;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        public string HashPassword(string password)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            Console.WriteLine($"Hashing password: {password} -> {hashedPassword}");
            return hashedPassword;
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            try
            {
                var isMatch = BCrypt.Net.BCrypt.Verify(password, hashedPassword);
                Console.WriteLine($"Verifying: {password} with {hashedPassword} -> {isMatch}");
                return isMatch;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error verifying password: {ex.Message}");
                throw;
            }
        }
    }
}
