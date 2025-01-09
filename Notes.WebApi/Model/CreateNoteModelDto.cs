using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.CreateNote;

namespace Notes.WebApi.Model;

public class CreateNoteModelDto : IMapWith<CreateNoteCommand>
{
    public required string Title { get; set; }
    public required string Details { get; set; }

    public CreateNoteModelDto(Profile profile)
    {
        profile.CreateMap<CreateNoteModelDto, CreateNoteCommand>()
            .ForMember(noteCommand => noteCommand.Title,
                opt => opt.MapFrom(noteDto => noteDto.Title))
            .ForMember(noteCommand => noteCommand.Details,
                opt => opt.MapFrom(noteDto => noteDto.Details));
    }
}