using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Application.Repositories;
using Notes.Domain;

namespace Notes.Persistence.Repositories;

public class NoteRepository(NotesDbContext context) : INoteRepository
{
    public async Task AddAsync(Note note, CancellationToken cancellationToken)
    {
        await context.AddAsync(note, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(Guid id, Guid userId, CancellationToken cancellationToken)
    {
        var note = await GetByIdTrackingAsync(id, userId, cancellationToken);

        context.Remove(note);
        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(UpdateNoteDto updateNoteDto, CancellationToken cancellationToken)
    {
        var note = await GetByIdTrackingAsync(updateNoteDto.Id, updateNoteDto.UserId, cancellationToken);

        note.Details = updateNoteDto.Details;
        note.Title = updateNoteDto.Title;
        note.EditDate = updateNoteDto.EditDate;

        await context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Note> GetByIdTrackingAsync(Guid id, Guid userId, CancellationToken cancellationToken)
    {
        var note = await context.Notes.FirstOrDefaultAsync(note => note.Id == id, cancellationToken);

        if (note == null || note.UserId != userId)
        {
            throw new NotFoundException(nameof(Note), id);
        }

        return note;
    }

    public async Task<NoteDetailsDto> GetByIdNoTrackingAsync(Guid id, Guid userId, CancellationToken cancellationToken)
    {
        var note = await context.Notes
                            .Select(note => new NoteDetailsDto()
                            {
                                Id = note.Id,
                                UserId = userId,
                                Title = note.Title,
                                Details = note.Details,
                                CreationDate = note.CreationDate,
                                EditDate = note.EditDate,
                            })
                            .AsNoTracking()
                            .FirstOrDefaultAsync(note => note.Id == id, cancellationToken);

        if (note == null || note.UserId != userId)
        {
            throw new NotFoundException(nameof(Note), id);
        }

        return note;
    }

    public async Task<IList<NoteListDto>> GetNotesByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var notes = await context.Notes
            .Select(note => new NoteListDto
            { 
                Id = note.Id,
                UserId = note.UserId,
                Title = note.Title,
            })
            .Where(note => note.UserId == userId)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return notes;
    }
}