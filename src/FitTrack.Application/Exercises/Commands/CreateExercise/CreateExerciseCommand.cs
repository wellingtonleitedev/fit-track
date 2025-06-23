using ErrorOr;

using FitTrack.Domain.Exercises;

using MediatR;

namespace FitTrack.Api.Application.Exercises.Commands.CreateExercise;

public record CreateExerciseCommand(
    string Name,
    string Sets,
    string? Rest = null,
    string? Description = null
) : IRequest<ErrorOr<Exercise>>;