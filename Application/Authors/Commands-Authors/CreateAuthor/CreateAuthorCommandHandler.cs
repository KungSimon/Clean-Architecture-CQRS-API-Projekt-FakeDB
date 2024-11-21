using Application.Books.Commands.CreateBook;
using Domain;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands_Authors.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, List<Author>>
    {
        //private readonly List<Author> _authors;
        //FakeDB should be used here
        private readonly FakeDatabase _fakeDatabase;

        public CreateAuthorCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        Task<List<Author>> IRequestHandler<CreateAuthorCommand, List<Author>>.Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            _fakeDatabase.AddNewAuthor(request.NewAuthor);
            return Task.FromResult(_fakeDatabase.Authors);
        }
    }
}
