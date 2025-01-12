using Notes.Application.Common.Exceptions;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.DeleteCommand;
using Notes.Persistence.Repositories;
using Notes.Tests.Common;

namespace Notes.Tests.Notes.Commands;

public class DeleteNoteCommandHandlerTests : TestCommandBase
{
    [Fact]
    public async Task DeleteNoteCommandHandler_Success()
    {
        // Arrange
        var noteRepository = new NoteRepository(Context);
        var handler = new DeleteNoteCommandHandler(noteRepository);

        // Act
        await handler.Handle(new DeleteNoteCommand
        {
            Id = NotesContextFactory.NoteIdForDelete,
            UserId = NotesContextFactory.UserAId
        }, CancellationToken.None);

        // Assert
        Assert.Null(Context.Notes.SingleOrDefault(note =>
            note.Id == NotesContextFactory.NoteIdForDelete));
    }

    [Fact]
    public async Task DeleteNoteCommandHandler_FailOnWrongId()
    {
        // Arrange
        var noteRepository = new NoteRepository(Context);
        var handler = new DeleteNoteCommandHandler(noteRepository);
        var deleteNoteCommand = new DeleteNoteCommand
        {
            Id = Guid.NewGuid(),
            UserId = NotesContextFactory.UserAId
        };

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await handler.Handle(
                deleteNoteCommand,
                CancellationToken.None));
    }

    [Fact]
    public async Task DeleteNoteCommandHandler_FailOnWrongUserId()
    {
        // Arrange

        var noteRepository = new NoteRepository(Context);
        var deleteHandler = new DeleteNoteCommandHandler(noteRepository);
        var createHandler = new CreateNoteCommandHandler(noteRepository);
        var createNoteCommand = new CreateNoteCommand
        {
            Title = "NoteTitle",
            UserId = NotesContextFactory.UserAId,
            Details = "",
        };

        var noteId = await createHandler.Handle(
            createNoteCommand, CancellationToken.None);

        // Act
        // Assert
        await Assert.ThrowsAsync<NotFoundException>(async () =>
            await deleteHandler.Handle(
                new DeleteNoteCommand
                {
                    Id = noteId,
                    UserId = NotesContextFactory.UserBId
                }, CancellationToken.None));
    }
}