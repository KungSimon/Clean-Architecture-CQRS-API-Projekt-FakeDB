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

namespace Application.Books.Commands.UpdateBook
{
    public class UpdateBookByIdCommandHandler : IRequestHandler<UpdateBookByIdCommand, OperationResult<Book>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<UpdateBookByIdCommandHandler> _logger;
        public UpdateBookByIdCommandHandler(IBookRepository bookRepository, ILogger<UpdateBookByIdCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task<OperationResult<Book>> Handle(UpdateBookByIdCommand request, CancellationToken cancellationToken)
        {
            var bookToUpdate = await _bookRepository.GetBookById(request.Id);
            try
            {
                _bookRepository.UpdateBook(request.Id, request.UpdatedBook);
                _logger.LogInformation("Book updated");
                return await Task.FromResult(OperationResult<Book>.Successfull(request.UpdatedBook));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Book not updated");
                return OperationResult<Book>.Failure("Book not updated");
            }
        }
    }
}

        //public async Task<OperationResult<Book>> Handle(UpdateBookByIdCommand request, CancellationToken cancellationToken)
        //{
        //_logger.LogInformation("Handling UpdateBookCommand for Book Id: {BookId}", request.Book?.Id);

        //try
        //{
        //if (request.Book == null)
        //{
        //_logger.LogWarning("UpdateBookCommand received with null Book.");
        //return OperationResult<Book?>.Failure("Book cannot be null.");
        //}

        //if (request.Book.Id == Guid.Empty)
        //{
        //_logger.LogWarning("UpdateBookCommand received with empty Id.");
        //return OperationResult<Book?>.Failure("Id cannot be empty.");
        //}

        //if (string.IsNullOrWhiteSpace(request.Book.Title))
        //{
        //_logger.LogWarning("UpdateBookCommand received with empty Book title.");
        //return OperationResult<Book?>.Failure("Book title cannot be empty.");
        //}

        //if (request.Book.Author == null)
        //{
        //_logger.LogWarning("UpdateBookCommand received with null Author.");
        //return OperationResult<Book?>.Failure("Author cannot be null.");
        //}

        //var existingBook = await _bookRepository.GetBookById(request.Book.Id);
        //if (existingBook == null)
        //{
        //_logger.LogWarning("UpdateBookCommand received for non-existent Book with Id: {BookId}", request.Book.Id);
        //return OperationResult<Book?>.Failure("Book with that ID does not exist.");
        //}

        //var updatedBook = await _bookRepository.UpdateBook(request.Book.Id, request.Book);
        //_logger.LogInformation("Book with Id: {BookId} updated successfully.", request.Book.Id);
        //return OperationResult<Book?>.Successfull(updatedBook);
        //}
        //catch (Exception ex)
        //{
        //_logger.LogError(ex, "An error occurred while updating the book with Id: {BookId}", request.Book?.Id);
        //return OperationResult<Book?>.Failure($"An error occurred while updating the book: {ex.Message}");
        //}
        //}
    

