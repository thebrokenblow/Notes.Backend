using MediatR;
using Notes.Application.Repositories;

namespace Notes.Application.Notes.Commands.UpdateNote;

public class UpdateNoteCommandHandler(INoteRepository noteRepository) : IRequestHandler<UpdateNoteCommand>
{
    public async Task Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var updateNoteDto = new UpdateNoteDto
        {
            Id = request.Id,
            UserId = request.UserId,
            Title = request.Title,
            Details = request.Details,
            EditDate = DateTime.UtcNow,
        };

        await noteRepository.UpdateAsync(updateNoteDto, cancellationToken);
    }
}
