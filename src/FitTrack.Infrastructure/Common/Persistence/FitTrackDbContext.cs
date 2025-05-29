using FitTrack.Domain.Users;

using Microsoft.EntityFrameworkCore;

namespace FitTrack.Infrastructure.Common.Persistence;

public class FitTrackDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public FitTrackDbContext(DbContextOptions options) : base(options) { }
}