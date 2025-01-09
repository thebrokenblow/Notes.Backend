using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Notes.Application.Repositories;

namespace Notes.Application.Notes.Queries.GetNoteList;

public class GetNoteListQueryHandler(INoteRepository noteRepository, IMapper mapper) : IRequestHandler<GetNoteListQuery, NoteListVm>
{
    public async Task<NoteListVm> Handle(GetNoteListQuery request, CancellationToken cancellationToken)
    {
        var notes = await noteRepository.GetNotesByUserIdAsync(request.UserId, cancellationToken);

        var noteLookupDto = notes
            .AsQueryable()
            .ProjectTo<NoteLookupDto>(mapper.ConfigurationProvider).ToList();

        return new NoteListVm
        {
            Notes = noteLookupDto
        };
    }
}