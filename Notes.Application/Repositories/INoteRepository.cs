using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Domain;

namespace Notes.Application.Repositories;

public interface INoteRepository
{
    Task AddAsync(Note note, CancellationToken cancellationToken);
    Task DeleteAsync(Guid id, Guid userId, CancellationToken cancellationToken);
    Task<Note> GetByIdTrackingAsync(Guid id, Guid userId, CancellationToken cancellationToken);
    Task<NoteDetailsDto> GetByIdNoTrackingAsync(Guid id, Guid userId, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateNoteDto updateNoteDto, CancellationToken cancellationToken);
    Task<IList<NoteListDto>> GetNotesByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}