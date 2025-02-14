using Application.Dtos;
using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Queries_Books.GetBook
{
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery ,OperationResult<Book>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<GetBookByIdQueryHandler> _logger;

        public GetBookByIdQueryHandler(IBookRepository bookRepository, ILogger<GetBookByIdQueryHandler> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }
        public async Task<OperationResult<Book>> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetBookByIdQuery for Book Id: {BookId}", request.Id);

            if(request.Id == Guid.Empty)
            {
                _logger.LogWarning("GetBookByIdQuery received with empty Id.");
                return OperationResult<Book>.Failure("Id cant be empty");
            }

            var book = await _bookRepository.GetBookById(request.Id);
            if(book == null)
            {
                _logger.LogWarning("GetBookByIdQuery received a non-existent Book with Id: {BookId}", request.Id);
                return OperationResult<Book>.Failure("Book was not found");
            }
            _logger.LogInformation("Book with Id: {BookId} found.", request.Id);
            return OperationResult<Book>.Successfull(book);

            //try
            //{
                //var bookToGet = _bookRepository.GetBookById(request.Id);
                //return Task.FromResult(OperationResult<Book>.Success(new Book
                //{
                    //Id = bookToGet.Id,
                    //Title = bookToGet.Title,
                    //Description = bookToGet.Description
                //}));
            //}
            //catch
            //{
                //return Task.FromResult(OperationResult<BookDto>.Failure("Book not found"));
            //}
        }
    }
}
