﻿using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Queries_Books.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<Book>>
    {
    }
}
