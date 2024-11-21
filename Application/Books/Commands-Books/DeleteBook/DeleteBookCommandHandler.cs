using Application.Books.Commands.CreateBook;
using Domain;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands_Books.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Book>
    {
        private readonly FakeDatabase _fakeDatabase;
        public DeleteBookCommandHandler(FakeDatabase fakeDatabase)
        {
            _fakeDatabase = fakeDatabase;
        }

        public Task<Book> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            Book bookToDelete = _fakeDatabase.Books.FirstOrDefault(book => book.Id == request.BookId)!;

            _fakeDatabase.Books.Remove(bookToDelete);

            return Task.FromResult(bookToDelete);
        }
    }
}
