using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands_Books.DeleteBook
{
    public class DeleteBookCommand : IRequest<Book>
    {
        public DeleteBookCommand(int _bookId)
        {
            BookId = _bookId;
        }
        
        public int BookId { get; }
    }
}
