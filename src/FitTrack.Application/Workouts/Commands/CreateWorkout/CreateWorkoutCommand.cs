using ErrorOr;
using MediatR;
using FitTrack.Domain.Workouts;

namespace FitTrack.Application.Workouts.Commands.CreateWorkout;

public record CreateWorkoutCommand(Guid TrainingId) : IRequest<ErrorOr<Workout>>;