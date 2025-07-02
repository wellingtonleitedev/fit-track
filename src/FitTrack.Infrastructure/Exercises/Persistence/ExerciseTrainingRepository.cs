using FitTrack.Domain.Exercises;
using FitTrack.Application.Common.Interfaces;
using FitTrack.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FitTrack.Infrastructure.Exercises.Persistence;

public class ExerciseTrainingRepository : IExerciseTrainingRepository
{
    private readonly FitTrackDbContext _dbContext;

    public ExerciseTrainingRepository(FitTrackDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddRangeAsync(List<ExerciseTraining> exercises)
    {
        await _dbContext.ExerciseTrainings.AddRangeAsync(exercises);
    }
}