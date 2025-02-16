using Application.Books.Queries_Books.GetBook;
using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Queries_Books.GetAllBooks
{
    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, OperationResult<List<Book>>>
    {
        //FakeDB should be used here
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<GetAllBooksQueryHandler> _logger;

        public GetAllBooksQueryHandler(IBookRepository bookRepository, ILogger<GetAllBooksQueryHandler> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task<OperationResult<List<Book>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetAllBookQuery");

            var books = await _bookRepository.GetAllBooksAsync();

            if (books == null || !books.Any())
            {
                _logger.LogWarning("No books found.");
                return OperationResult<List<Book>>.Failure("No books found");
            }
            _logger.LogInformation("Found {BookCount} books", books.Count());
            return OperationResult<List<Book>>.Successfull(books.ToList(), "Books retrived successfully.");
        }
    }
}
