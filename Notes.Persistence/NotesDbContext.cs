using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using Notes.Persistence.Extensions;

namespace Notes.Persistence;

public class NotesDbContext(DbContextOptions<NotesDbContext> options) : DbContext(options)
{
    public required DbSet<Note> Notes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyAllConfigurations();
        base.OnModelCreating(modelBuilder);
    }
}