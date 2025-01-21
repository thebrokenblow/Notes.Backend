using Notes.Application.Common.Exceptions;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Tests.Common;

namespace Notes.Tests.Notes.Commands;

public class UpdateNoteCommandHandlerTests : TestBase
{
    [Fact]
    public async Task UpdateNoteCommandHandler_FailOnWrongId()
    {
        // Arrange

        var handler = new UpdateNoteCommandHandler(noteRepository);
        var updateNoteCommand = new UpdateNoteCommand
        {
            Id = Guid.NewGuid(),
            Title = "",
            Details = "",
            UserId = NotesContextFactory.UserAId
        };

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                updateNoteCommand,
                CancellationToken.None));
    }

    [Fact]
    public async Task UpdateNoteCommandHandler_FailOnWrongUserId()
    {
        // Arrange

        var handler = new UpdateNoteCommandHandler(noteRepository);
        var updateNoteCommand = new UpdateNoteCommand
        {
            Id = NotesContextFactory.NoteIdForUpdate,
            UserId = NotesContextFactory.UserAId,
            Title = "",
            Details = ""
        };

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
        {
            await handler.Handle(
                updateNoteCommand, 
                CancellationToken.None);
        });
    }
}