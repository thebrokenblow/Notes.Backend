using AutoMapper;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Persistence;
using Notes.Persistence.Repositories;
using Notes.Tests.Common;

namespace Notes.Tests.Notes.Queries;

[Collection("QueryCollection")]
public class GetNoteDetailsQueryHandlerTests(QueryTestFixture fixture)
{
    private readonly NotesDbContext Context = fixture.Context;
    private readonly IMapper Mapper = fixture.Mapper;

    [Fact]
    public async Task GetNoteDetailsQueryHandler_Success()
    {
        // Arrange
        
        var noteRepository = new NoteRepository(Context);
        var handler = new GetNoteDetailsQueryHandler(noteRepository, Mapper);

        // Act
        var result = await handler.Handle(
            new GetNoteDetailsQuery
            {
                UserId = NotesContextFactory.UserBId,
                Id = Guid.Parse("909F7C29-891B-4BE1-8504-21F84F262084")
            },
            CancellationToken.None);

        // Assert

        Assert.Equal("Title2", result.Title);
        Assert.Equal(DateTime.Today, result.CreationDate);
    }
}