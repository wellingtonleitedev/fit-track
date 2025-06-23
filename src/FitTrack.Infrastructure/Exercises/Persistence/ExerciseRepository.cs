using FitTrack.Domain.Exercises;
using FitTrack.Application.Common.Interfaces;
using FitTrack.Infrastructure.Common.Persistence;

namespace FitTrack.Infrastructure.Exercises.Persistence;

public class ExerciseRepository : IExerciseRepository
{
    private readonly FitTrackDbContext _dbContext;

    public ExerciseRepository(FitTrackDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Exercise exercise)
    {
        await _dbContext.AddAsync(exercise);
    }
}