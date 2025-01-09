using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain;

namespace Notes.Persistence.EntityTypeConfigurations;

public class NoteConfiguration : IEntityTypeConfiguration<Note>
{
    public void Configure(EntityTypeBuilder<Note> builder)
    {
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
            .HasMaxLength(250)
            .HasColumnName("title");

        builder
            .Property(note => note.Details)
            .HasMaxLength(1000)
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