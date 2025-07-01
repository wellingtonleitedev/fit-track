using FitTrack.Domain.Users;
using FitTrack.Domain.Workouts;
using FitTrack.Domain.Exercises;
using FitTrack.Domain.Trainings;
using Microsoft.EntityFrameworkCore;
using FitTrack.Domain.TrainingExercises;
using FitTrack.Application.Common.Interfaces;
using System.Reflection;

namespace FitTrack.Infrastructure.Common.Persistence;

public class FitTrackDbContext : DbContext, IUnitOfWork
{
    public DbSet<User> Users { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Training> Trainings { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<TrainingExercise> TrainingExercises { get; set; }

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