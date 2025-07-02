using ErrorOr;
using MediatR;
using FitTrack.Domain.Workouts;

namespace FitTrack.Application.Workouts.Commands.UpdateWorkout;

public record ExerciseRecordCommand(
    Guid ExerciseId,
    int Reps,
    double Weight
);

public record UpdateWorkoutCommand(
    Guid WorkoutId,
    List<ExerciseRecordCommand> Records
) : IRequest<ErrorOr<Workout>>;