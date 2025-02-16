using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Queries_Authors.GetAuthor
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, OperationResult<Author>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<GetAuthorByIdQueryHandler> _logger;

        public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository, ILogger<GetAuthorByIdQueryHandler> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }
        public async Task<OperationResult<Author>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var authorToGet = await _authorRepository.GetAuthorByIdAsync(request.Id);
                if (authorToGet == null)
                {
                    _logger.LogError("Author not found");
                    return OperationResult<Author>.Failure("Author not found");
                }
                _logger.LogInformation("Author found");
                return OperationResult<Author>.Successfull(authorToGet);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the author");
                return OperationResult<Author>.Failure("An error occurred while getting the author");
            }
        }
    }
}