using MediatR;
using Notes.Application.Repositories;

namespace Notes.Application.Notes.Queries.GetNoteList;

public class GetNoteRangeHandler(INoteRepository noteRepository) : IRequestHandler<GetNoteRangeQuery, List<NoteItemVm>>
{
    public async Task<List<NoteItemVm>> Handle(GetNoteRangeQuery request, CancellationToken cancellationToken)
    {
        var notesItemVmDto = await noteRepository.GetRangeByUserIdAsync(
            request.UserId, 
            request.CountSkip, 
            request.CountTake, 
            cancellationToken);

        return NoteItemVmDto.Map(notesItemVmDto);
    }
}