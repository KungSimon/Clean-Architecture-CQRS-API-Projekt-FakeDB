using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands_Authors.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest<OperationResult<List<Author>>>
    {
        public DeleteAuthorCommand(Guid authorId)
        {
            AuthorId = authorId;
        }

        public Guid AuthorId { get; }
    }
}
