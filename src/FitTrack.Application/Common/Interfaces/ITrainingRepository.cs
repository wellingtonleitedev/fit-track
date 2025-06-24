using FitTrack.Domain.Trainings;

namespace FitTrack.Application.Common.Interfaces;

public interface ITrainingRepository
{
    Task AddAsync(Training training);
}