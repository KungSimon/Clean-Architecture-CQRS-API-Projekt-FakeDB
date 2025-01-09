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
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, OperationResult<Author?>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly ILogger<DeleteAuthorCommandHandler> _logger;
        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository, ILogger<DeleteAuthorCommandHandler>logger)
        {
            _authorRepository = authorRepository;
            _logger = logger;
        }

        //public Task<string> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        //{
        //var deletedAuthor =  _authorRepository.DeleteAuthor(request.AuthorId);
        //return Task.FromResult("authorToDelete");
        //}

        public async Task<OperationResult<Author?>> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var deletedAuthor = await _authorRepository.DeleteAuthor(request.AuthorId);
                _logger.LogInformation("Author Deleted");
                return OperationResult<Author?>.Successfull(deletedAuthor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Author not Deleted");
                return OperationResult<Author?>.Failure("Author not Deleted");
            }
        }
    }
}
