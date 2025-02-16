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
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, OperationResult<List<Author>>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<GetAuthorByIdQueryHandler> _logger;

        public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository, ILogger<GetAuthorByIdQueryHandler> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }
        public async Task<OperationResult<List<Author>>> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(request.Id);
            if (author == null)
            {
                return OperationResult<List<Author>>.Failure($"Author with ID {request.Id} not found");
            }
            return OperationResult<List<Author>>.Successfull(new List<Author> { author }, "Test Author");
        }
    }
}