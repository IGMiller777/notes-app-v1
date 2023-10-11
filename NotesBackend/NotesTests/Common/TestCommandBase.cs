using Notes.Persistence;

namespace NotesTests.Common;

public class TestCommandBase : IDisposable
{
    protected readonly NotesDbContext Context;

    public TestCommandBase()
    {
        Context = NotesContextFactory.Create();
    }

    public void Dispose()
    {
        NotesContextFactory.Destroy(Context);
    }
}