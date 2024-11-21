using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands_Authors.UpdateAuthor
{
    public class UpdateAuthorByIdCommand : IRequest<Author>
    {
        public UpdateAuthorByIdCommand(int _authorId, Author _updatedAuthor)
        {
            AuthorId = _authorId;
            UpdatedAuthor = _updatedAuthor;
        }

        public int AuthorId { get; }
        public Author UpdatedAuthor { get; }
    }
}
