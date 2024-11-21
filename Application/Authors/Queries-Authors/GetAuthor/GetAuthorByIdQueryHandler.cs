using Domain;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Queries_Authors.GetAuthor
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly FakeDatabase _fakeDatabase;

        public GetAuthorByIdQueryHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }
        public Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            Author authorToGet = _fakeDatabase.Authors.FirstOrDefault(Author => Author.Id == request.Id)!;

            Author wantedAuthor = _fakeDatabase.Authors.Where(Author => Author.Id == request.Id).FirstOrDefault()!;

            return Task.FromResult(authorToGet);
            return Task.FromResult(wantedAuthor);
        }
    }
}