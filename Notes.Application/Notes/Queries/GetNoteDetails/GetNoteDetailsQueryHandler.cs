using AutoMapper;
using MediatR;
using Notes.Application.Repositories;

namespace Notes.Application.Notes.Queries.GetNoteDetails;

public class GetNoteDetailsQueryHandler(INoteRepository noteRepository) : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
{
    public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken) =>
        await noteRepository.GetDetailsByIdAsync(request.Id, request.UserId, cancellationToken);
}