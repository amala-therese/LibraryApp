using libApplication.Features.LendingFeatures.Commands;
using libApplication.Features.LendingFeatures.Queries;
using MediatR;
using libDomain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class LendingController : ControllerBase
{
    private readonly IMediator _mediator;

    public LendingController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LendingHistory>>> GetLendingHistory()
    {
        var query = new GetAllLendingHistoriesQuery();
        var history = await _mediator.Send(query);
        return Ok(history);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LendingHistory>> GetLendingHistory(int id)
    {
        var query = new GetLendingHistoryByIdQuery { Id = id };
        var history = await _mediator.Send(query);
        if (history == null)
        {
            return NotFound();
        }
        return Ok(history);
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateLendingHistory([FromBody] CreateLendingHistoryCommand command)
    {
        var lendingId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetLendingHistory), new { id = lendingId }, lendingId);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateLendingHistory(int id, [FromBody] UpdateLendingHistoryCommand command)
    {
        if (id != command.LendingID)
        {
            return BadRequest();
        }
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLendingHistory(int id)
    {
        var command = new DeleteLendingHistoryCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
