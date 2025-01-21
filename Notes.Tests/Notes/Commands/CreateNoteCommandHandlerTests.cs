using Microsoft.EntityFrameworkCore;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Tests.Common;

namespace Notes.Tests.Notes.Commands;

public class CreateNoteCommandHandlerTests : TestBase
{
    [Fact]
    public async Task CreateNoteCommandHandler_Success()
    {
        // Arrange

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

        var note = await context.Notes.SingleOrDefaultAsync(
            note =>
                note.Id == noteId && 
                note.Title == noteName &&
                note.Details == noteDetails);

        Assert.NotNull(note);
    }
}