using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, OperationResult<Book>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<CreateBookCommandHandler> _logger;

        public CreateBookCommandHandler(IBookRepository bookRepository, ILogger<CreateBookCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task<OperationResult<Book>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.NewBook.Title) || string.IsNullOrEmpty(request.NewBook.Description))
            {
                return OperationResult<Book>.Failure("Title and Description are required");
            }

            // Create a new book using the Book constructor
            var newBook = new Book(request.NewBook.Id, request.NewBook.Title, request.NewBook.Description);

            // Save the book using the repository
            await _bookRepository.AddBookAsync(newBook);

            // Return a successful operation result with the new book
            return OperationResult<Book>.Successfull(newBook);
        }
    }
}
