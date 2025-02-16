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

namespace Application.Authors.Commands_Authors.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, OperationResult<Author>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<CreateAuthorCommandHandler> _logger;
        public CreateAuthorCommandHandler(IAuthorRepository authorRepository, ILogger<CreateAuthorCommandHandler> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }

        public async Task<OperationResult<Author>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.GetAllAuthorsAsync();
            if (authors.Any(author => author.Name == request.NewAuthor.Name))
            {
                return OperationResult<Author>.Failure("An author already exists with that name"); 
            }
            var newAuthor = new Author
            {
                Id = Guid.NewGuid(),
                Name = request.NewAuthor.Name,
                Bio = request.NewAuthor.Bio
            };

            await _authorRepository.AddAuthorAsync(newAuthor);
            return OperationResult<Author>.Successfull(newAuthor, "Author successfully added");
         }
    }
}
