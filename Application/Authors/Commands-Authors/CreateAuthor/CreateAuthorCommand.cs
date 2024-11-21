using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Authors.Commands_Authors.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<List<Author>>
    {
        public CreateAuthorCommand(Author authorToAdd)
        {
            NewAuthor = authorToAdd;
        }

        public Author NewAuthor { get; }
    }
}
