using FitTrack.Domain.Workouts;
using Microsoft.EntityFrameworkCore;
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

    public async Task<Workout?> GetByIdAsync(Guid id)
    {
        return await _context.Workouts.FirstOrDefaultAsync(w => w.Id == id);
    }

    public Task UpdateAsync(Workout workout)
    {
        _context.Workouts.Update(workout);
        return Task.CompletedTask;
    }
}