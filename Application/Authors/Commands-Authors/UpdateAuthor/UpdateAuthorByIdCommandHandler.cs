using Application.Interfaces.RepositoryInterfaces;
using Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands_Authors.UpdateAuthor
{
    public class UpdateAuthorByIdCommandHandler : IRequestHandler<UpdateAuthorByIdCommand, OperationResult<List<Author>>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<UpdateAuthorByIdCommandHandler> _logger;

        public UpdateAuthorByIdCommandHandler(IAuthorRepository authorRepository, ILogger<UpdateAuthorByIdCommandHandler> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }

        public async Task<OperationResult<List<Author>>> Handle(UpdateAuthorByIdCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.GetAuthorByIdAsync(request.UpdatedAuthor.Id);
            if (author == null)
            {
                return OperationResult<List<Author>>.Failure("Author not found.");
            }

            author.Name = request.UpdatedAuthor.Name;

            await _authorRepository.AddAuthorAsync(author);

            var authors = await _authorRepository.GetAllAuthorsAsync();
            return OperationResult<List<Author>>.Successfull(authors.ToList(), "Author successfully updated.");
        }
    }
}
