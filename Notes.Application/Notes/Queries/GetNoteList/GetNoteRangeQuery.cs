using MediatR;

namespace Notes.Application.Notes.Queries.GetNoteList;

public class GetNoteRangeQuery : IRequest<List<NoteItemVm>>
{
    public required Guid UserId { get; set; }
    public required int CountSkip { get; set; }
    public required int CountTake { get; set; }

}