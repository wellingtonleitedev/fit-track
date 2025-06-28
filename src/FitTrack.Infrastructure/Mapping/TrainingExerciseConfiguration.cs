using Microsoft.EntityFrameworkCore;
using FitTrack.Domain.TrainingExercises;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitTrack.Infrastructure.Mapping;

public class TrainingExerciseConfiguration : IEntityTypeConfiguration<TrainingExercise>
{
    public void Configure(EntityTypeBuilder<TrainingExercise> builder)
    {
        builder.HasKey(te => te.Id);

        builder.Property(te => te.Id).HasColumnType("uuid");

        builder.HasKey(te => new { te.ExerciseId, te.TrainingId });

        builder.HasOne(te => te.Training)
            .WithMany(t => t.TrainingExercise)
            .HasForeignKey(te => te.TrainingId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(te => te.Exercise)
            .WithMany(e => e.TrainingExercise)
            .HasForeignKey(te => te.ExerciseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(te => te.Order);

        builder.Property(te => te.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(te => te.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnUpdate();
    }
}