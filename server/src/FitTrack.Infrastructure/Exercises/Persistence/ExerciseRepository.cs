using FitTrack.Domain.Exercises;
using FitTrack.Application.Common.Interfaces;
using FitTrack.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;

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
        await _dbContext.Exercises.AddAsync(exercise);
    }

    public async Task<List<Exercise>> GetListByIdAsync(List<Guid> ids)
    {
        return await _dbContext.Exercises.Where(exercise => ids.Contains(exercise.Id)).ToListAsync();
    }
}