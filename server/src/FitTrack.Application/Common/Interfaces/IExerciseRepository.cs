using FitTrack.Domain.Exercises;

namespace FitTrack.Application.Common.Interfaces;

public interface IExerciseRepository
{
    Task AddAsync(Exercise exercise);
    Task<List<Exercise>> GetListByIdAsync(List<Guid> ids);
}