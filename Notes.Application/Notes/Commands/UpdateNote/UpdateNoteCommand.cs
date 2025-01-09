using MediatR;
using System.Globalization;

namespace Notes.Application.Notes.Commands.UpdateNote;

public class UpdateNoteCommand : IRequest
{
    public required Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required string Title { get; set; }
    public required string Details { get; set; }
}
