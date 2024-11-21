using Domain;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands_Authors.UpdateAuthor
{
    public class UpdateAuthorByIdCommandHandler : IRequestHandler<UpdateAuthorByIdCommand, Author>
    {
        private readonly FakeDatabase _fakeDatabase;

        public UpdateAuthorByIdCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<Author> Handle(UpdateAuthorByIdCommand request, CancellationToken cancellationToken)
        {
            Author authorToUpdate = _fakeDatabase.Authors.FirstOrDefault(Author => Author.Id == request.AuthorId)!;

            authorToUpdate.Name = request.UpdatedAuthor.Name;
            authorToUpdate.Bio = request.UpdatedAuthor.Bio;

            return Task.FromResult(authorToUpdate);
        }
    }
}
