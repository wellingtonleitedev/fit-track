using FitTrack.Domain.Users;
using FitTrack.Domain.Exercises;
using Microsoft.EntityFrameworkCore;
using FitTrack.Application.Common.Interfaces;
using FitTrack.Domain.Trainings;

namespace FitTrack.Infrastructure.Common.Persistence;

public class FitTrackDbContext : DbContext, IUnitOfWork
{
    public DbSet<User> Users { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<Training> Trainings { get; set; }

    public FitTrackDbContext(DbContextOptions options) : base(options) { }

    public async Task CommitChangesAsync()
    {
        await base.SaveChangesAsync();
    }
}