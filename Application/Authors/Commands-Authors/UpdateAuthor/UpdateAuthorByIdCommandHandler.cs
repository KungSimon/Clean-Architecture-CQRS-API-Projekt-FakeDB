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

            // Update the author's properties
            author.Name = request.UpdatedAuthor.Name;

            // Save changes
            await _authorRepository.AddAuthorAsync(author);

            // Return the updated list of authors
            var authors = await _authorRepository.GetAllAuthorsAsync();
            return OperationResult<List<Author>>.Successfull(authors.ToList(), "Author successfully updated.");
        }

        //async Task<OperationResult<Author>> IRequestHandler<UpdateAuthorByIdCommand, OperationResult<Author>>.Handle(UpdateAuthorByIdCommand request, CancellationToken cancellationToken)
        //{
            //var authorToUpdate = _authorRepository.GetAuthorById(request.AuthorId);
            //try
            //{
                //_authorRepository.UpdateAuthor(request.AuthorId,request.UpdatedAuthor);
                //_logger.LogInformation("Author updated");
                //return await Task.FromResult(OperationResult<Author>.Successfull(request.UpdatedAuthor));
            //}
            //catch (Exception ex)
            //{
                //_logger.LogError(ex, "Author not updated");
                //return OperationResult<Author>.Failure("Author not updated");
            //}
        //}
    }
}
