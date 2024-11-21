using Application;
using Application.Authors.Commands_Authors.CreateAuthor;
using Application.Authors.Commands_Authors.DeleteAuthor;
using Application.Authors.Commands_Authors.UpdateAuthor;
using Application.Authors.Queries_Authors.GetAllAuthors;
using Application.Authors.Queries_Authors.GetAuthor;
using Application.Books.Commands.CreateBook;
using Application.Books.Commands.UpdateBook;
using Application.Books.Commands_Books.DeleteBook;
using Application.Books.Queries_Books.GetAllBooks;
using Application.Books.Queries_Books.GetBook;
using Domain;
using Infrastructure.Database;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        //private readonly FakeDatabase _database;
        internal readonly IMediator _mediator;


        //public AuthorController(FakeDatabase database, IMediator mediator)
        //{
            //_database = database;
            //_mediator = mediator;
        //}

        public AuthorController(IMediator mediator)
        {
            //_database = database;
            _mediator = mediator;
        }


        //[HttpPost]
        //[Route("addNewAuthor")]
        //public async void Post([FromBody] Author authorToAdd)
        //{
        //await _mediator.Send(new CreateAuthorCommand(authorToAdd));
        //}

        [HttpPost]
        [Route("addNewAuthor")]
        public async Task<IActionResult> Post([FromBody] Author authorToAdd)
        {
            return Ok(await _mediator.Send(new CreateAuthorCommand(authorToAdd)));
        }

        [HttpGet]
        [Route("getAuthorById/{authorId}")]
        public async Task<IActionResult> GetAuthorById(int authorId)
        {
            return Ok(await _mediator.Send(new GetAuthorByIdQuery(authorId)));
        }

        [HttpGet]
        [Route("getAllAuthors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = (await _mediator.Send(new GetAllAuthorsQuery()));
            return Ok(authors);
            //return Ok("GET ALL BOOKS");
        }

        [HttpPatch]
        [Route("updateAuthor/{authorId}")]
        public async Task<IActionResult> UpdateAuthor(int authorId, [FromBody] Author author)
        {
            return Ok(await _mediator.Send(new UpdateAuthorByIdCommand(authorId, author)));
        }

        [HttpDelete]
        [Route("deleteAuthor/{authorId}")]
        public async Task<IActionResult> DeleteAuthor(int authorId)
        {
            return Ok(await _mediator.Send(new DeleteAuthorCommand(authorId)));
        }
    }
}
