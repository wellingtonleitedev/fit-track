using ErrorOr;

using FitTrack.Application.Common.Interfaces;
using FitTrack.Domain.Workouts;

using MediatR;

namespace FitTrack.Application.Workouts.Commands.UpdateWorkout;

public class UpdateWorkoutCommandHandler : IRequestHandler<UpdateWorkoutCommand, ErrorOr<Workout>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWorkoutRepository _workoutRepository;
    private readonly IWorkoutRecordRepository _workoutRecordRepository;

    public UpdateWorkoutCommandHandler(
        IUnitOfWork unitOfWork,
        IWorkoutRepository workoutRepository,
        IWorkoutRecordRepository workoutRecordRepository
    )
    {
        _unitOfWork = unitOfWork;
        _workoutRepository = workoutRepository;
        _workoutRecordRepository = workoutRecordRepository;
    }

    public async Task<ErrorOr<Workout>> Handle(UpdateWorkoutCommand command, CancellationToken cancellationToken)
    {
        var workout = await _workoutRepository.GetByIdAsync(command.WorkoutId);

        if (workout is null)
        {
            return Error.NotFound(
                $"Workout with ID {command.WorkoutId} not found."
            );
        }

        var records = command.Records
            .Select(record => new WorkoutRecord
            {
                Reps = record.Reps,
                Weight = record.Weight,
                WorkoutId = workout.Id,
                ExerciseId = record.ExerciseId,
            }).ToList();
        await _workoutRecordRepository.AddRangeAsync(records);

        workout.EndDate = DateTime.Now;
        await _workoutRepository.UpdateAsync(workout);
        
        await _unitOfWork.CommitChangesAsync();

        return workout;
    }
}