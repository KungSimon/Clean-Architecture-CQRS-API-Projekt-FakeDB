﻿using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Queries_Books.GetBook
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
