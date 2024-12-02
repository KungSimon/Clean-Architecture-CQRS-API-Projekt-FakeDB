﻿using Domain;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands_User.AddNewUser
{
    public class AddNewCommandHandler : IRequestHandler<AddNewUserCommand, User>
    {
        private readonly FakeDatabase _fakeDatabase;
        public AddNewCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }
        public Task<User> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
        {
            User userToCreate = new User
            {
                Id = Guid.NewGuid(),
                UserName = request.NewUser.UserName,
                Password = request.NewUser.Password
            };
            _fakeDatabase.Users.Add(userToCreate);
            return Task.FromResult(userToCreate);
        }
    }
}
