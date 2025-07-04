using ErrorOr;
using MediatR;
using FitTrack.Domain.Workouts;
using FitTrack.Application.Common.Interfaces;

namespace FitTrack.Application.Workouts.Commands.CreateWorkout;

public class CreateWorkoutCommandHandler : IRequestHandler<CreateWorkoutCommand, ErrorOr<Workout>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWorkoutRepository _repository;

    public CreateWorkoutCommandHandler(IWorkoutRepository repository, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _repository = repository;
    }

    public async Task<ErrorOr<Workout>> Handle(CreateWorkoutCommand command, CancellationToken cancellationToken)
    {
        var workout = new Workout
        {
            TrainingId = command.TrainingId
        };

        await _repository.AddAsync(workout);
        await _unitOfWork.CommitChangesAsync();

        return workout;
    }
}