using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Tests.Common;

namespace Notes.Tests.Notes.Queries;

public class GetNoteListQueryHandlerTests : TestBase
{
    [Fact]
    public async Task GetNoteListQueryHandler_Success()
    {
        // Arrange

        var handler = new GetNoteRangeHandler(noteRepository);
        var getNoteRangeQuery = new GetNoteRangeQuery
        {
            CountSkip = 0,
            CountTake = 2,
            UserId = NotesContextFactory.UserBId
        };

        // Act

        var result = await handler.Handle(
            getNoteRangeQuery,
            CancellationToken.None);
        
        // Assert

        Assert.Empty(result);
    }
}