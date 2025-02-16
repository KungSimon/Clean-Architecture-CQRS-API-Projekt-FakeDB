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
        private readonly IMediator _mediator;
        

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        [Route("addNewBook")]
        public async Task<IActionResult> AddBook([FromBody] Book book)
        {
            var command = new CreateBookCommand(book);
            var result = await _mediator.Send(command);
            return Ok(result);


            //return Ok(await _mediator.Send(new CreateBookCommand(book)));
        }

        [HttpGet]
        [Route("getBookById/{bookId}")]
        public async Task<IActionResult> GetBookById(Guid bookId)
        {
            var query = new GetBookByIdQuery(bookId);
            var result = await _mediator.Send(query);
            return Ok(result);


            //return Ok(await _mediator.Send(new GetBookByIdQuery(bookId)));
        }

        [Authorize]
        [HttpGet]
        [Route("getAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {

            var query = new GetAllBooksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);

            //var books = (await _mediator.Send(new GetAllBooksQuery()));
            //return Ok(books);
            //return Ok("GET ALL BOOKS");
        }

        [HttpPatch]
        [Route("updateBook/{bookId}")]
        public async Task<IActionResult> UpdateBook(Guid bookId, [FromBody] Book book)
        {
            //book.Id = bookId;
            var command = new UpdateBookByIdCommand(book);
            var result = await _mediator.Send(command);
            return Ok(result);


            //return Ok(await _mediator.Send(new UpdateBookByIdCommand(book, bookId)));
        }

        [HttpDelete]
        [Route("deleteBook/{bookId}")]
        public async Task<IActionResult> DeleteBook(Guid bookId)
        {
            var commmand = new DeleteBookCommand(bookId);
            var result = await _mediator.Send(commmand);    
            return Ok(result);

            //return Ok(await _mediator.Send(new DeleteBookCommand(bookId)));
        }
    }
}
