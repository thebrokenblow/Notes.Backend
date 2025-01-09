using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.DeleteCommand;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.WebApi.Model;

namespace Notes.WebApi.Controllers;


public class NoteController(IMediator mediator, IMapper mapper) : BaseController(mediator)
{
    [Route("api/[controller]")]
    public async Task<ActionResult<NoteListVm>> GetAll()
    {
        var query = new GetNoteListQuery
        {
            UserId = UserId,
        };

        var vm = await _mediator.Send(query);

        return Ok(vm);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<NoteDetailsVm>> Get(Guid id)
    {
        var query = new GetNoteDetailsQuery
        {
            UserId = UserId,
            Id = id
        };

        var vm = await _mediator.Send(query);

        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateNoteModelDto createNoteDto)
    {
        var command = mapper.Map<CreateNoteCommand>(createNoteDto);
        command.UserId = UserId;
        
        var noteId = await _mediator.Send(command);
        
        return Ok(noteId);
    }

    [HttpPut]
    public async Task<ActionResult<Guid>> Update([FromBody] UpdateNoteModelDto updateNoteModelDto)
    {
        var command = mapper.Map<UpdateNoteCommand>(updateNoteModelDto);
        command.UserId = UserId;

        await _mediator.Send(command);

        return NoContent();
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteNoteCommand
        {
            Id = id,
            UserId = UserId
        };

        await _mediator.Send(command);

        return NoContent();
    }
}