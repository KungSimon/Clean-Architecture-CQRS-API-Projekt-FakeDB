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
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, OperationResult<List<Book>>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<CreateBookCommandHandler> _logger;

        public CreateBookCommandHandler(IBookRepository bookRepository, ILogger<CreateBookCommandHandler> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task<OperationResult<List<Book>>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetAllBooksAsync();
            if(books.Any(book => book.Title == request.NewBook.Title))
            {
                return OperationResult<List<Book>>.Failure("A book with this title already exists");
            }

            await _bookRepository.AddBookAsync(request.NewBook);

            books = await _bookRepository.GetAllBooksAsync();
            return OperationResult<List<Book>>.Successfull(books.ToList(), "Book sucessfully added");
        }
    }
}
