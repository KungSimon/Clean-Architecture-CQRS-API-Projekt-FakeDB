using Domain;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries_Users.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly FakeDatabase _fakeDatabase;

        public GetAllUsersQueryHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }
        public Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<User> allUsersFromFakeDB = _fakeDatabase.Users;
            return Task.FromResult(allUsersFromFakeDB);
        }
    }
}