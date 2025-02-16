using Application.Authors.Commands_Authors.CreateAuthor;
using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands_Authors.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, OperationResult<List<Author>>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<DeleteAuthorCommandHandler> _logger;
        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository, ILogger<DeleteAuthorCommandHandler>logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }

        public async Task<OperationResult<List<Author>>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(request.AuthorId);
            if (author == null)
            {
                return OperationResult<List<Author>>.Failure("Author not found.");
            }
            await _authorRepository.DeleteAuthorAsync(request.AuthorId);

            var authors = await _authorRepository.GetAllAuthorsAsync();
            return OperationResult<List<Author>>.Successfull(authors.ToList(), "Author successfully deleted.");
        }
    }
}
