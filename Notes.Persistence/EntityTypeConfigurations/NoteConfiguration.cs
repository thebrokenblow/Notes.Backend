using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain;

namespace Notes.Persistence.EntityTypeConfigurations;

public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    private const int maxLengthTitle = 250;
    private const int maxLengthDetails = 1000;

    public void Configure(EntityTypeBuilder<Note> builder)
    {
        builder
           .ToTable("notes");

        builder
            .HasKey(note => note.Id);

        builder
            .HasIndex(note => note.Id)
            .IsUnique();

        builder
            .Property(note => note.Id)
            .HasColumnName("id");

        builder
            .Property(note => note.Title)
            .IsRequired()
            .HasMaxLength(maxLengthTitle)
            .HasColumnName("title");

        builder
            .Property(note => note.Details)
            .IsRequired()
            .HasMaxLength(maxLengthDetails)
            .HasColumnName("details");

        builder
            .Property(note => note.CreationDate)
            .IsRequired()
            .HasColumnName("creation_date");

        builder
            .Property(note => note.EditDate)
            .IsRequired(false)
            .HasColumnName("edit_date");

        builder
            .Property(note => note.UserId)
            .IsRequired()
            .HasColumnName("user_id");
    }
}