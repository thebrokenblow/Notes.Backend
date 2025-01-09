namespace Notes.Application.Notes.Queries.GetNoteList;

public class NoteListVm
{
    public required IList<NoteLookupDto> Notes { get; set; }
}
