using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands_Authors.UpdateAuthor
{
    public class UpdateAuthorByIdCommand : IRequest<OperationResult<List<Author>>>
    {
        public UpdateAuthorByIdCommand(Author updatedAuthor)
        {
            UpdatedAuthor = updatedAuthor;
        }

        public Author UpdatedAuthor { get; }
    }
}
