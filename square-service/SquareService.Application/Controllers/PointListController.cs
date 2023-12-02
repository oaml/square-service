using MediatR;
using Microsoft.AspNetCore.Mvc;
using SquareService.Application.Commands;
using SquareService.Application.Models;
using SquareService.Application.Queries;
using SquareService.Domain.Aggregates.PointList;
using SquareService.Domain.DomainExceptions;
using SquareService.Domain.ValueObjects;

namespace SquareService.Application.Controllers;

[ApiController]
[Route("pointList")]
public class PointListController : ControllerBase
{
    private readonly IMediator _mediator;
    public PointListController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{pointListId}")]
    [ProducesResponseType(StatusCodes.Status200OK)] 
    [ProducesResponseType(StatusCodes.Status404NotFound)] 
    public async Task<ActionResult<PointList>> GetPointList([FromRoute] int pointListId)
    {
        try
        {
            var pointList = await _mediator.Send(new GetPointListQuery(pointListId));
            return Ok(pointList);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"PointList with the provided Id: {pointListId} was not found");
        }
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)] 
    [ProducesResponseType(StatusCodes.Status400BadRequest)] 
    public async Task<IActionResult> CreateNewPointList([FromBody] CreateNewPointListModel model)
    {
        try
        {
            var newPointListId = await _mediator.Send(new CreatePointListCommand(model.Points));
            return CreatedAtAction(nameof(GetPointList), new { pointListId = newPointListId }, newPointListId);
        }
        catch (DuplicatePointException)
        {
            return BadRequest("Points array contains duplicate points");
        }
    }
    
    [HttpPost("{pointListId}/point")]
    [ProducesResponseType(StatusCodes.Status201Created)] 
    [ProducesResponseType(StatusCodes.Status400BadRequest)] 
    [ProducesResponseType(StatusCodes.Status404NotFound)] 
    public async Task<IActionResult> AddPointToExistingList([FromRoute]int pointListId, [FromBody] AddNewPointModel model)
    {
        try
        {
            await _mediator.Send(new AddPointInPointListCommand(pointListId, model.Point));
            return CreatedAtAction(nameof(GetPointList), new { pointListId = pointListId }, pointListId);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"PointList with the provided Id: {pointListId} was not found");
        }
        catch (DuplicatePointException)
        {
            return BadRequest($"Point with the provided (X, Y): ({model.Point.X}, {model.Point.Y}) already exists");
        }
    }
    
    [HttpDelete("{pointListId}/point")]
    [ProducesResponseType(StatusCodes.Status200OK)] 
    [ProducesResponseType(StatusCodes.Status404NotFound)] 
    public async Task<IActionResult> DeletePointFromExistingList([FromRoute]int pointListId, [FromBody] AddNewPointModel model)
    {
        try
        {
            await _mediator.Send(new DeletePointInPointListCommand(pointListId, model.Point));
            return Ok();
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"PointList with the provided Id: {pointListId} was not found");
        }
        catch (PointNotFoundException)
        {
            return NotFound($"Point with the provided (X, Y): ({model.Point.X}, {model.Point.Y})  was not found");
        }
    }
    
    [HttpGet("{pointListId}/squares")]
    [ProducesResponseType(StatusCodes.Status200OK)] 
    [ProducesResponseType(StatusCodes.Status404NotFound)] 
    public async Task<ActionResult<IEnumerable<Square>>> GetSquaresFromPointList([FromRoute]int pointListId)
    {
        try
        {
            return Ok(await _mediator.Send(new GetSquaresFromPointListQuery(pointListId)));
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"PointList with the provided Id: {pointListId} was not found");
        }
    }
}