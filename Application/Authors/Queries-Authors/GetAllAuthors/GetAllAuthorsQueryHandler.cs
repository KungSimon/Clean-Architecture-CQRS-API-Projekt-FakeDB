using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Queries_Authors.GetAllAuthors
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, OperationResult<List<Author>>>
    {
        //FakeDB should be used here
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<GetAllAuthorsQueryHandler> _logger;
        public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository, ILogger<GetAllAuthorsQueryHandler> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }

        public async Task<OperationResult<List<Author>>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.GetAllAuthorsAsync();
            if(!authors.Any())
            {
                return OperationResult<List<Author>>.Failure("No authors found"); 
            }

            return OperationResult<List<Author>>.Successfull(authors.ToList(), "Authors retrived successfully");
        }
    }
}
