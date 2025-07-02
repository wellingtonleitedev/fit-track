using FitTrack.Domain.Workouts;

namespace FitTrack.Application.Common.Interfaces;

public interface IWorkoutRepository
{
    Task AddAsync(Workout workout);
    Task<Workout?> GetByIdAsync(Guid id);
    Task UpdateAsync(Workout workout);
}