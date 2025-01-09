using MediatR;
using Notes.Application.Repositories;

namespace Notes.Application.Notes.Commands.DeleteCommand;

public class DeleteNoteCommandHandler(INoteRepository noteRepository) : IRequestHandler<DeleteNoteCommand>
{
    public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken) =>
        await noteRepository.DeleteAsync(request.Id, request.UserId, cancellationToken);
}