using AutoMapper;
using Notes.Application.Common.Mappings;

namespace Notes.Application.Notes.Queries.GetNoteList;

public class NoteLookupDto : IMapWith<NoteListDto>
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<NoteListDto, NoteLookupDto>()
            .ForMember(noteDto => noteDto.Id,
                opt => opt.MapFrom(note => note.Id))
            .ForMember(noteDto => noteDto.Title,
                opt => opt.MapFrom(note => note.Title));
    }
}