namespace Notes.Domain;

public class Note
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Details { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? EditDate { get; set; }
}
