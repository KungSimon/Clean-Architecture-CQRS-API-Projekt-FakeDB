using Domain;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Queries_Books.GetBook
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery ,Book>
    {
        private readonly FakeDatabase _fakeDatabase;

        public GetBookByIdQueryHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }
        public Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            Book bookToGet = _fakeDatabase.GetBookById(request.Id);

            Book wantedBok = _fakeDatabase.Books.Where(Book => Book.Id == request.Id).FirstOrDefault()!;

            return Task.FromResult(wantedBok);

            bookToGet = _fakeDatabase.GetBookById(request.Id);
            //bookToGet.Title = request.GetBook.Title;


            return Task.FromResult(bookToGet);
        }
    }
}
