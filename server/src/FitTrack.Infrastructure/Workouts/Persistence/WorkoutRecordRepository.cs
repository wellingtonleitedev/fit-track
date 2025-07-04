using FitTrack.Domain.Workouts;
using FitTrack.Application.Common.Interfaces;
using FitTrack.Infrastructure.Common.Persistence;

namespace FitTrack.Infrastructure.Workouts.Persistence;

public class WorkoutRecordRepository : IWorkoutRecordRepository
{
    private readonly FitTrackDbContext _context;

    public WorkoutRecordRepository(FitTrackDbContext context)
    {
        _context = context;
    }

    public async Task AddRangeAsync(List<WorkoutRecord> records)
    {
        await _context.WorkoutRecords.AddRangeAsync(records);
    }
}