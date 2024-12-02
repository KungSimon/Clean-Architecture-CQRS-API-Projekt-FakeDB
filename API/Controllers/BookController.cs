using Application;
using Application.Books.Commands.CreateBook;
using Application.Books.Commands.UpdateBook;
using Application.Books.Commands_Books.DeleteBook;
using Application.Books.Queries_Books.GetAllBooks;
using Application.Books.Queries_Books.GetBook;
using Domain;
using Infrastructure.Database;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        //CRUD GET UPDATE/PUT/PATCH POST DELETE
        //private readonly FakeDatabase _database;
        internal readonly IMediator _mediator;

        //public BookController(FakeDatabase database, IMediator mediator)
        //{
            //_database = database;
            //_mediator = mediator;
        //}

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpPost]
        //[Route("addNewBook")]
        //public async void Post([FromBody] Book bookToAdd)
        //{
        //await _mediator.Send(new CreateBookCommand(bookToAdd));
        //}

        [HttpPost]
        [Route("addNewBook")]
        public async Task<IActionResult> Post([FromBody] Book bookToAdd)
        {
            return Ok(await _mediator.Send(new CreateBookCommand(bookToAdd)));
        }

        [HttpGet]
        [Route("getBookById/{bookId}")]
        public async Task<IActionResult> GetBookById(int bookId)
        {
            return Ok(await _mediator.Send(new GetBookByIdQuery(bookId)));
        }

        [Authorize]
        [HttpGet]
        [Route("getAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {

            var books = (await _mediator.Send(new GetAllBooksQuery()));
            return Ok(books);
            //return Ok("GET ALL BOOKS");
        }

        [HttpPatch]
        [Route("updateBook/{bookId}")]
        public async Task<IActionResult> UpdateBook(int bookId, [FromBody] Book book)
        {
            return Ok(await _mediator.Send(new UpdateBookByIdCommand(book, bookId)));
        }

        [HttpDelete]
        [Route("deleteBook/{bookId}")]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            return Ok(await _mediator.Send(new DeleteBookCommand(bookId)));
        }
    }
}
