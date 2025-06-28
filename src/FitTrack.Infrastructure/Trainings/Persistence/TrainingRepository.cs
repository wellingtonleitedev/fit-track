
using FitTrack.Domain.Trainings;
using FitTrack.Application.Common.Interfaces;
using FitTrack.Infrastructure.Common.Persistence;

namespace FitTrack.Infrastructure.Trainings.Persistence;

public class TrainingRepository : ITrainingRepository
{
    private readonly FitTrackDbContext _dbContext;

    public TrainingRepository(FitTrackDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Training training)
    {
        await _dbContext.Trainings.AddAsync(training);
    }
}