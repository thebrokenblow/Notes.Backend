using AutoMapper;
using Notes.Application.Common.Mappings;
using Notes.Application.Notes.Commands.UpdateNote;

namespace Notes.WebApi.Model;

public class UpdateNoteModelDto : IMapWith<UpdateNoteModelDto>
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Details { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateNoteModelDto, UpdateNoteCommand>()
            .ForMember(noteCommand => noteCommand.Id,
                opt => opt.MapFrom(noteDto => noteDto.Id))
            .ForMember(noteCommand => noteCommand.Title,
                opt => opt.MapFrom(noteDto => noteDto.Title))
            .ForMember(noteCommand => noteCommand.Details,
                opt => opt.MapFrom(noteDto => noteDto.Details));
    }
}