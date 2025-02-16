using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.UpdateBook
{
    public class UpdateBookByIdCommand : IRequest<OperationResult<List<Book>>>
    {
        public UpdateBookByIdCommand(Book updatedBook)
        {
            UpdatedBook = updatedBook;
        }

        public Book UpdatedBook { get; set; }
    }
}
