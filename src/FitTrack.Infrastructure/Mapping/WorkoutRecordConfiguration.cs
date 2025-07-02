using FitTrack.Domain.Workouts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitTrack.Infrastructure.Mapping;

public class WorkoutRecordConfiguration : IEntityTypeConfiguration<WorkoutRecord>
{
    public void Configure(EntityTypeBuilder<WorkoutRecord> builder)
    {
        builder.ToTable("workout_records");
        
        builder.HasKey(wr => wr.Id);
        builder.Property(wr => wr.Id).HasColumnType("uuid");

        builder.Property(wr => wr.Reps)
            .IsRequired()
            .HasDefaultValue(0);

        builder.Property(wr => wr.Weight)
            .IsRequired()
            .HasDefaultValue(0.0);

        builder.Property(wr => wr.CreatedAt)
            .IsRequired()
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(wr => wr.UpdatedAt)
            .IsRequired()
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasOne(wr => wr.Workout)
            .WithMany(w => w.Records)
            .HasForeignKey(wr => wr.WorkoutId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(wr => wr.Exercise)
            .WithMany(e => e.Records)
            .HasForeignKey(wr => wr.ExerciseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}