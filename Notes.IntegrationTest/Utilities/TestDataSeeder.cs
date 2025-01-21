using Bogus;
using Notes.Domain;
using Notes.Persistence;

namespace Notes.IntegrationTests.Utilities;

public class TestDataSeeder
{
    public static void Seed(NotesDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        var notes = new Faker<Note>()
            .RuleFor(note => note.UserId, faker => Guid.NewGuid())
            .RuleFor(note => note.Id, faker => Guid.NewGuid())
            .RuleFor(note => note.Title, faker => faker.Lorem.Sentence(3))
            .RuleFor(note => note.Details, faker => faker.Lorem.Paragraph(3))
            .RuleFor(note => note.CreationDate, faker => faker.Date.Past())
            .RuleFor(note => note.EditDate, faker => faker.Date.Future());

        var testNotes = notes.Generate(10);

        context.Notes.AddRange(testNotes);
        context.SaveChanges();

        var t = context.Notes.Count();
    }

    public static void Destroy(NotesDbContext context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}