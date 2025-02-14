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
    public class UpdateBookByIdCommand : IRequest<OperationResult<Book>>
    {
        public UpdateBookByIdCommand(Book updatedBook, Guid id)
        {
            UpdatedBook = updatedBook;
            Id = id;
        }

        public Book UpdatedBook { get; }
        public Guid Id { get; }
    }
}
