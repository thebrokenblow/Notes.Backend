using AutoMapper;
using MediatR;
using Notes.Application.Repositories;

namespace Notes.Application.Notes.Queries.GetNoteList;

public class GetNoteListQueryHandler(INoteRepository noteRepository, IMapper mapper) : IRequestHandler<GetNoteListQuery, NoteListVm>
{
    public async Task<NoteListVm> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
    {
        var notes = await noteRepository.GetNotesByUserIdAsync(request.UserId, cancellationToken);

        var noteLookupDtos = new List<NoteLookupDto>();

        for (int i = 0; i < notes.Count; i++)
        {
            var noteLookupDto = new NoteLookupDto
            {
                Id = notes[i].Id,
                Title = notes[i].Title,
            };

            noteLookupDtos.Add(noteLookupDto);
        }

        return new NoteListVm
        {
            Notes = noteLookupDtos
        };
    }
}