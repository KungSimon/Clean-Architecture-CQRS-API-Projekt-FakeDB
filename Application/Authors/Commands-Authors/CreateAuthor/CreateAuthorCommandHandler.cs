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

         async Task<OperationResult<Author>> IRequestHandler<CreateAuthorCommand, OperationResult<Author>>.Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
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
            };

            await _authorRepository.AddAuthorAsync(newAuthor);
            return OperationResult<Author>.Successfull(newAuthor, "Author successfully added");


            try
            {
                _authorRepository.AddAuthorAsync(request.NewAuthor);
                _logger.LogInformation("Author created");
                return await Task.FromResult(OperationResult<Author>.Successfull(request.NewAuthor));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Author not created");
                return OperationResult<Author>.Failure("Author not created");
            }
         }
    }
}
