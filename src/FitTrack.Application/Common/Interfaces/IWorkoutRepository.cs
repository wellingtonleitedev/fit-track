using FitTrack.Domain.Workouts;

namespace FitTrack.Application.Common.Interfaces;

public interface IWorkoutRepository
{
    Task AddAsync(Workout workout);
}