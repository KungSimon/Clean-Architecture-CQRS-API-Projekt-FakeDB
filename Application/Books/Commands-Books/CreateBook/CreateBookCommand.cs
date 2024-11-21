using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Books.Commands.CreateBook
{
    public class CreateBookCommand : IRequest<List<Book>>
    {
        public CreateBookCommand(Book newBook) 
        {
            NewBook = newBook;
        }

        public Book NewBook { get; }


    }
}
