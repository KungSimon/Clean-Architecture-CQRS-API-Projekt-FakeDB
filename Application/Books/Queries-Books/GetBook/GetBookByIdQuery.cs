using Application.Dtos;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Queries_Books.GetBook
{
    public class GetBookByIdQuery : IRequest<OperationResult<Book>> 
    {
        public GetBookByIdQuery(Guid id)
        {
           Id = id;
        }

        public Guid Id { get; }
    }
}
