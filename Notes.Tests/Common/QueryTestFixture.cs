using Notes.Persistence;

namespace Notes.Tests.Common;

public class QueryTestFixture : IDisposable
{
    public NotesDbContext Context;

    public QueryTestFixture()
    {
        Context = NotesContextFactory.Create();
    }

    public void Dispose()
    {
        NotesContextFactory.Destroy(Context);
    }
}