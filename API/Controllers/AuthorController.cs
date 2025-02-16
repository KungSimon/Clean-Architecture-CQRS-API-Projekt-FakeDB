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
        private readonly IMediator _mediator;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(IMediator mediator, ILogger<AuthorController> logger)
        {   
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [Route("addNewAuthor")]
        public async Task<IActionResult> AddAuthor([FromBody] Author author)
        {
            try
            {
                var command = new CreateAuthorCommand(author);
                var result = await _mediator.Send(command);
                return Ok(result);
                //return CreatedAtAction(nameof(GetAuthorById), new { id = result.Result.Id }, result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("getAuthorById/{authorId}")]
        public async Task<IActionResult> GetAuthorById(Guid id)
        {

            try
            {
                var query = new GetAuthorByIdQuery(id);
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }

            //return Ok(await _mediator.Send(new GetAuthorByIdQuery(id)));
        }

        [HttpGet]
        [Route("getAllAuthors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            try
            {
                var query = new GetAllAuthorsQuery();
                var result = await _mediator.Send(query);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An unexpected error occurred.", details = ex.Message });
            }
        

        var authors = (await _mediator.Send(new GetAllAuthorsQuery()));
            return Ok(authors);
            //return Ok("GET ALL BOOKS");
        }

        [HttpPatch]
        [Route("updateAuthor/{id}")]
        public async Task<IActionResult> UpdateAuthor(Guid id, [FromBody] Author author)
        {
            try
            {
                //author.Id = id;
                var command = new UpdateAuthorByIdCommand(author);
                var result = await _mediator.Send(command);
                return Ok(result);

            }
            catch(ArgumentException ex)
            {
                return NotFound(new { message = ex.Message }); 
            }

            //return Ok(await _mediator.Send(new UpdateAuthorByIdCommand(id, author)));
        }

        [HttpDelete]
        [Route("deleteAuthor/{authorId}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            try
            {
                var command = new DeleteAuthorCommand(id);
                await _mediator.Send(command);
                return NoContent();
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            //return Ok(await _mediator.Send(new DeleteAuthorCommand(authorId)));
        }
    }
}
