using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands_Authors.UpdateAuthor
{
    public class UpdateAuthorByIdCommand : IRequest<OperationResult<Author>>
    {
        public UpdateAuthorByIdCommand(Guid _authorId, Author _updatedAuthor)
        {
            AuthorId = _authorId;
            UpdatedAuthor = _updatedAuthor;
        }

        public Guid AuthorId { get; }
        public Author UpdatedAuthor { get; }
    }
}
