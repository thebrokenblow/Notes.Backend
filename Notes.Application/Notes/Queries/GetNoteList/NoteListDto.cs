namespace Notes.Application.Notes.Queries.GetNoteList;

public class NoteListDto
{
    public required Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required string Title { get; set; }
}