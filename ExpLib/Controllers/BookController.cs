using libApplication.Features.Bookfeatures.Commands;
using libApplication.Features.Bookfeatures.Queries;
using MediatR;
using libDomain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IMediator _mediator;

    public BookController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
    {
        var query = new GetAllBooksQuery();
        var books = await _mediator.Send(query);
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var query = new GetBookByIdQuery { Id = id };
        var book = await _mediator.Send(query);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateBook([FromBody] AddBookCommand command)
    {
        var bookId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetBook), new { id = bookId }, bookId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBook(int id, [FromBody] UpdateBookCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBook(int id)
    {
        var command = new DeleteBookCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
