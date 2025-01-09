using MediatR;
using Notes.Application.Repositories;
using Notes.Domain;

namespace Notes.Application.Notes.Commands.CreateNote;

public class CreateNoteCommandHandler(INoteRepository noteRepository) : IRequestHandler<CreateNoteCommand, Guid>
{
    public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var note = new Note
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Title = request.Title,
            Details = request.Details,
            CreationDate = DateTime.UtcNow,
        };

        await noteRepository.AddAsync(note, cancellationToken);

        return note.Id;
    }
}