using System.Reflection;
using FitTrack.Domain.Workouts;
using FitTrack.Domain.Exercises;
using FitTrack.Domain.Trainings;
using Microsoft.EntityFrameworkCore;
using FitTrack.Application.Common.Interfaces;

namespace FitTrack.Infrastructure.Common.Persistence;

public class FitTrackDbContext : DbContext, IUnitOfWork
{
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<WorkoutRecord> WorkoutRecords { get; set; }
    public DbSet<ExerciseTraining> ExerciseTrainings { get; set; }


    public FitTrackDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }

    public async Task CommitChangesAsync()
    {
        await base.SaveChangesAsync();
    }
}