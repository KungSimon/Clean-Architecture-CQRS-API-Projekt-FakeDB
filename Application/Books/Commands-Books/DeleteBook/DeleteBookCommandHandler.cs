using Application.Books.Commands.CreateBook;
using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands_Books.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, OperationResult<List<Book>>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<DeleteBookCommandHandler> _logger;
        public DeleteBookCommandHandler(IBookRepository bookRepository, ILogger<DeleteBookCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task<OperationResult<List<Book>>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookByIdAsync(request.BookId);
            if (book == null)
            {
                return OperationResult<List<Book>>.Failure("Book not found.");
            }

            await _bookRepository.DeleteBookAsync(request.BookId);

            var books = await _bookRepository.GetAllBooksAsync();
            return OperationResult<List<Book>>.Successfull(books.ToList(), "Book sucessfully deleted");

        }
    }
}
