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
    public class UpdateAuthorByIdCommandHandler : IRequestHandler<UpdateAuthorByIdCommand, OperationResult<Author>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<UpdateAuthorByIdCommandHandler> _logger;

        public UpdateAuthorByIdCommandHandler(IAuthorRepository authorRepository, ILogger<UpdateAuthorByIdCommandHandler> logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }

        //public async Task<Author> Handle(UpdateAuthorByIdCommand request, CancellationToken cancellationToken)
        //{
            //try
            //{
                //_authorRepository.UpdateAuthor(request.AuthorId);

            //}
            //catch (Exception ex)
            //{
                //return null;
            //}
            ////Author authorToUpdate = _fakeDatabase.Authors.FirstOrDefault(Author => Author.Id == request.AuthorId)!;

            ////authorToUpdate.Name = request.UpdatedAuthor.Name;
            ////authorToUpdate.Bio = request.UpdatedAuthor.Bio;

            ////return Task.FromResult(authorToUpdate);
        //}

        async Task<OperationResult<Author>> IRequestHandler<UpdateAuthorByIdCommand, OperationResult<Author>>.Handle(UpdateAuthorByIdCommand request, CancellationToken cancellationToken)
        {
            var authorToUpdate = _authorRepository.GetAuthorById(request.AuthorId);
            try
            {
                _authorRepository.UpdateAuthor(request.AuthorId,request.UpdatedAuthor);
                _logger.LogInformation("Author updated");
                return await Task.FromResult(OperationResult<Author>.Successfull(request.UpdatedAuthor));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Author not updated");
                return OperationResult<Author>.Failure("Author not updated");
            }
        }
    }
}
