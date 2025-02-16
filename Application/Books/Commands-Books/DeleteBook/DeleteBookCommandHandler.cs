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
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, OperationResult<Book>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<DeleteBookCommandHandler> _logger;
        public DeleteBookCommandHandler(IBookRepository bookRepository, ILogger<DeleteBookCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task<OperationResult<Book>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling RemoveBookCommand for Book Id: {BookId}", request.BookId);

            try
            {
                if (request.BookId == Guid.Empty)
                {
                    _logger.LogWarning("RemoveBookCommand received with empty Id.");
                    return OperationResult<Book?>.Failure("Id cannot be empty.");
                }

                var book = await _bookRepository.GetBookByIdAsync(request.BookId);
                if (book == null)
                {
                    _logger.LogWarning("RemoveBookCommand received for non-existent Book with Id: {BookId}", request.BookId);
                    return OperationResult<Book?>.Failure("Book not found.");
                }

                await _bookRepository.DeleteBookAsync(request.BookId);
                _logger.LogInformation("Book with Id: {BookId} removed successfully.", request.BookId);
                return OperationResult<Book?>.Successfull(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while removing the book with Id: {BookId}", request.BookId);
                return OperationResult<Book?>.Failure($"An error occurred while removing the book: {ex.Message}");
            }
        }
    }
}
