using FitTrack.Domain.Exercises;

namespace FitTrack.Application.Common.Interfaces;

public interface IExerciseTrainingRepository
{
    Task AddRangeAsync(List<ExerciseTraining> exercise);
}