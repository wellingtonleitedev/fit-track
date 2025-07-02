using FitTrack.Domain.Workouts;

namespace FitTrack.Application.Common.Interfaces;

public interface IWorkoutRecordRepository
{
    Task AddRangeAsync(List<WorkoutRecord> records);
}