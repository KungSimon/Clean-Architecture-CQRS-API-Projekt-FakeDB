using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands_Books.DeleteBook
{
    public class DeleteBookCommand : IRequest<OperationResult<Book>>
    {
        public DeleteBookCommand(Guid _bookId)
        {
            BookId = _bookId;
        }
        
        public Guid BookId { get; }
    }
}
