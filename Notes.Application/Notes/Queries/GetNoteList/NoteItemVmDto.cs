namespace Notes.Application.Notes.Queries.GetNoteList;

public class NoteItemVmDto
{
    public required Guid Id { get; set; }
    public required Guid UserId { get; set; }
    public required string Title { get; set; }

    public static List<NoteItemVm> Map(List<NoteItemVmDto> noteItemsVmDto)
    {
        var noteItemsVm = new List<NoteItemVm>();

        for (int i = 0; i < noteItemsVmDto.Count; i++)
        {
            var noteItemVm = new NoteItemVm
            {
                Id = noteItemsVmDto[i].Id,
                Title = noteItemsVmDto[i].Title,
            };

            noteItemsVm.Add(noteItemVm);
        }

        return noteItemsVm;
    }
}