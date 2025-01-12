using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Domain;

namespace Notes.Application.Notes.Queries.GetNoteDetails;

public class NoteDetailsVm : IMapWith<NoteDetailsDto>
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Details { get; set; }
    public required DateTime CreationDate { get; set; }
    public DateTime? EditDate { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Note, NoteDetailsVm>()
            .ForMember(noteVm => noteVm.Id,
                opt => opt.MapFrom(note => note.Id))
            .ForMember(noteVm => noteVm.Title,
                opt => opt.MapFrom(note => note.Title))
            .ForMember(noteVm => noteVm.Details,
                opt => opt.MapFrom(note => note.Details))
            .ForMember(noteVm => noteVm.CreationDate,
                opt => opt.MapFrom(note => note.CreationDate))
            .ForMember(noteVm => noteVm.EditDate,
                opt => opt.MapFrom(note => note.EditDate));
    }
}