using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Tests.Common;

namespace Notes.Tests.Notes.Queries;

public class GetNoteDetailsQueryHandlerTests : TestBase
{
    [Fact]
    public async Task GetNoteDetailsQueryHandler_Success()
    {
        // Arrange
        
        var handler = new GetNoteDetailsQueryHandler(noteRepository);
        var getNoteDetailsQuery = new GetNoteDetailsQuery
        {
            UserId = NotesContextFactory.UserBId,
            Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084")
        };

        // Act

        var result = await handler.Handle(
            getNoteDetailsQuery,
            CancellationToken.None);

        // Assert

        Assert.Equal("Title2", result.Title);
        Assert.Equal(DateTime.Today, result.CreationDate);
    }
}