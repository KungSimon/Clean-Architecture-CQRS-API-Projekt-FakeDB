using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Queries_Authors.GetAuthor
{
    public class GetAuthorByIdQuery : IRequest<OperationResult<List<Author>>>
    {
        public GetAuthorByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
