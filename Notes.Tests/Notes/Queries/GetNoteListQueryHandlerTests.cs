using AutoMapper;
using Notes.Application.Notes.Queries.GetNoteList;
using Notes.Persistence;
using Notes.Persistence.Repositories;
using Notes.Tests.Common;

namespace Notes.Tests.Notes.Queries;

[Collection("QueryCollection")]
public class GetNoteListQueryHandlerTests(QueryTestFixture fixture)
{
    private readonly NotesDbContext Context = fixture.Context;
    private readonly IMapper Mapper = fixture.Mapper;

    [Fact]
    public async Task GetNoteListQueryHandler_Success()
    {
        // Arrange

        var noteRepository = new NoteRepository(Context);
        var handler = new GetNoteListQueryHandler(noteRepository, Mapper);

        // Act
        
        var result = await handler.Handle(
            new GetNoteListQuery
            {
                UserId = NotesContextFactory.UserBId
            },
            CancellationToken.None);
        
        // Assert

        Assert.Equal(2, result.Notes.Count);
    }
}