using FitTrack.Domain.Trainings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitTrack.Infrastructure.Trainings.Mapping;

public class TrainingConfiguration : IEntityTypeConfiguration<Training>
{
    public void Configure(EntityTypeBuilder<Training> builder)
    {
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasColumnType("uuid");

        builder.Property(t => t.Name).IsRequired();

        builder.Property(t => t.Day)
            .HasConversion<string>()
            .HasMaxLength(10);

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate();

    }
}