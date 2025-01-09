using Application.Dtos;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands_User.AddNewUser
{
    public class AddNewUserCommand : IRequest <OperationResult<User>>
    {
        public AddNewUserCommand(User newUser)
        {
            NewUser = newUser;
        }

        public User NewUser { get; }
    }
}
