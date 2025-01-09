using MediatR;

namespace Notes.Application.Notes.Commands.CreateNote;

public class CreateNoteCommand : IRequest<Guid>
{
    public required Guid UserId { get; set; }
    public required string Title { get; set; }
    public required string Details { get; set; }
}