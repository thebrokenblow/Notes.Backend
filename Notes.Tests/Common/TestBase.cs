using Notes.Persistence;
using Notes.Persistence.Repositories;

namespace Notes.Tests.Common;

public abstract class TestBase : IDisposable
{
    protected readonly NoteRepository noteRepository;
    protected readonly NotesDbContext context;

    public TestBase()
    {
        context = NotesContextFactory.Create();
        noteRepository = new(context);
    }

    public void Dispose()
    {
        NotesContextFactory.Destroy(context);
    }
}