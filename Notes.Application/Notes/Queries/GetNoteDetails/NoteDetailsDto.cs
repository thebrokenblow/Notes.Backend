namespace Notes.Application.Notes.Queries.GetNoteDetails;

public record NoteDetailsDto
{
    public required Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required string Title { get; set; }
    public required string Details { get; set; }
    public required DateTime CreationDate { get; set; }
    public required DateTime? EditDate { get; set; }
}