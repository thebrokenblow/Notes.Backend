using Microsoft.EntityFrameworkCore;
using Notes.Application.Common.Exceptions;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Persistence.Repositories;
using Notes.Tests.Common;

namespace Notes.Tests.Notes.Commands;

public class UpdateNoteCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task UpdateNoteCommandHandler_Success()
    {
        // Arrange
        var noteRepository = new NoteRepository(Context);
        var handler = new UpdateNoteCommandHandler(noteRepository);
        var updatedTitle = "new title";
        
        // Act
        await handler.Handle(new UpdateNoteCommand
        {
            Id = NotesContextFactory.NoteIdForUpdate,
            UserId = NotesContextFactory.UserBId,
            Title = updatedTitle,
            Details = ""
        }, CancellationToken.None);

        // Assert
        Assert.NotNull(await Context.Notes.SingleOrDefaultAsync(note =>
            note.Id == NotesContextFactory.NoteIdForUpdate &&
            note.Title == updatedTitle));
    }
    [Fact]
    public async Task UpdateNoteCommandHandler_FailOnWrongId()
    {
        // Arrange

        var noteRepository = new NoteRepository(Context);
        var handler = new UpdateNoteCommandHandler(noteRepository);
        
        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                new UpdateNoteCommand
                {
                    Id = Guid.NewGuid(),
                    Title = "",
                    Details = "",
                    UserId = NotesContextFactory.UserAId
                },
                CancellationToken.None));
    }
    [Fact]
    public async Task UpdateNoteCommandHandler_FailOnWrongUserId()
    {
        // Arrange
        var noteRepository = new NoteRepository(Context);
        var handler = new UpdateNoteCommandHandler(noteRepository);
        
        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            await handler.Handle(
                new UpdateNoteCommand
                {
                    Id = NotesContextFactory.NoteIdForUpdate,
                    UserId = NotesContextFactory.UserAId,
                    Title = "",
                    Details = ""
                },
                CancellationToken.None);
        });
    }
}