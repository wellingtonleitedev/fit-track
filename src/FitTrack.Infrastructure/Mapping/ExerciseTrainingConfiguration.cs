using FitTrack.Domain.Exercises;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitTrack.Infrastructure.Mapping;

public class ExerciseTrainingConfiguration : IEntityTypeConfiguration<ExerciseTraining>
{
    public void Configure(EntityTypeBuilder<ExerciseTraining> builder)
    {
        builder.ToTable("exercise_trainings");

        builder.HasKey(te => te.Id);
        builder.Property(te => te.Id).HasColumnType("uuid");

        builder.HasKey(te => new { te.ExerciseId, te.TrainingId });

        builder.HasOne(te => te.Training)
            .WithMany(t => t.ExerciseTrainings)
            .HasForeignKey(te => te.TrainingId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(te => te.Exercise)
            .WithMany(e => e.ExerciseTrainings)
            .HasForeignKey(te => te.ExerciseId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(te => te.Order).IsRequired(false);

        builder.Property(te => te.CreatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAdd();

        builder.Property(te => te.UpdatedAt)
            .HasDefaultValueSql("CURRENT_TIMESTAMP")
            .ValueGeneratedOnAddOrUpdate();
    }
}