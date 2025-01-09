using AutoMapper;
using MediatR;
using Notes.Application.Repositories;

namespace Notes.Application.Notes.Queries.GetNoteDetails;

public class GetNoteDetailsQueryHandler(INoteRepository noteRepository, IMapper mapper) : IRequestHandler<GetNoteDetailsQuery, NoteDetailsVm>
{
    public async Task<NoteDetailsVm> Handle(GetNoteDetailsQuery request, CancellationToken cancellationToken)
    {
        var note = await noteRepository.GetByIdNoTrackingAsync(request.Id, request.UserId, cancellationToken);

        var noteDetailsVm = mapper.Map<NoteDetailsVm>(note);

        return noteDetailsVm;
    }
}
