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
    public class UpdateBookByIdCommandHandler : IRequestHandler<UpdateBookByIdCommand, OperationResult<List<Book>>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<UpdateBookByIdCommandHandler> _logger;
        public UpdateBookByIdCommandHandler(IBookRepository bookRepository, ILogger<UpdateBookByIdCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }


        public async Task<OperationResult<List<Book>>> Handle(UpdateBookByIdCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookByIdAsync(request.UpdatedBook.Id);
            if(book == null)
            {
                _logger.LogError("Book not updated");
                return OperationResult<List<Book>>.Failure("Book not found");
            }

            book.Title = request.UpdatedBook.Title;
            book.Description = request.UpdatedBook.Description;
            book.AuthorId = request.UpdatedBook.AuthorId;
            //book.Id = request.UpdatedBook.Id;

            await _bookRepository.UpdateBookAsync(book);
            _logger.LogInformation("Book updated");
            var books = await _bookRepository.GetAllBooksAsync();
            return OperationResult<List<Book>>.Successfull(books.ToList(), "Book successfully uppdated");
        }
    }
}



