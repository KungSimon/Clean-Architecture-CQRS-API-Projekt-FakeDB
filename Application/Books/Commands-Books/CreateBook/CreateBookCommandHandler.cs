using Domain;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, List<Book>>
    {
        //FakeDB should be used here
        private readonly FakeDatabase _fakeDatabase;

        public CreateBookCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        Task<List<Book>> IRequestHandler<CreateBookCommand, List<Book>>.Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            _fakeDatabase.AddNewBook(request.NewBook);
            return Task.FromResult(_fakeDatabase.Books);
        }
    }
}
