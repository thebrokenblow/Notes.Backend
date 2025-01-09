namespace Notes.Application.Notes.Commands.UpdateNote;

public record UpdateNoteDto
{
    public required Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required string Title { get; set; }
    public required string Details { get; set; }
    public required DateTime EditDate { get; set; }
}