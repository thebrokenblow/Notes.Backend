using Microsoft.EntityFrameworkCore;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Persistence.Repositories;
using Notes.Tests.Common;

namespace Notes.Tests.Notes.Commands;

public class CreateNoteCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task CreateNoteCommandHandler_Success()
    {
        // Arrange

        var noteRepository = new NoteRepository(Context);
        var handler = new CreateNoteCommandHandler(noteRepository);

        var noteName = "note name";
        var noteDetails = "note details";

        var createNoteCommand = new CreateNoteCommand
        {
            Title = noteName,
            Details = noteDetails,
            UserId = NotesContextFactory.UserAId
        };

        // Act
        var noteId = await handler.Handle(
            createNoteCommand,
            CancellationToken.None);
        
        // Assert
        Assert.NotNull(
            await Context.Notes.SingleOrDefaultAsync(note =>
                note.Id == noteId && note.Title == noteName &&
                note.Details == noteDetails));
    }
}