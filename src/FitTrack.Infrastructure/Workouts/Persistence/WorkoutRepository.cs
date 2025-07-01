using FitTrack.Domain.Workouts;
using FitTrack.Application.Common.Interfaces;
using FitTrack.Infrastructure.Common.Persistence;

namespace FitTrack.Infrastructure.Workouts.Persistence;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly FitTrackDbContext _context;

    public WorkoutRepository(FitTrackDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Workout workout)
    {
        await _context.Workouts.AddAsync(workout);
    }
}