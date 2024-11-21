using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Queries_Authors.GetAllAuthors
{
    public class GetAllAuthorsQuery : IRequest<List<Author>>
    {
        //public GetAllAuthorsQuery(List<Author> authors)
        //{
            //Authors = authors;
        //}

        //public List<Author> Authors { get; }
    }
}
