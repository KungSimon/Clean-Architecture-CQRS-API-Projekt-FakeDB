﻿using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Queries_Authors.GetAllAuthors
{
    public record GetAllAuthorsQuery : IRequest<OperationResult<List<Author>>>;
}
