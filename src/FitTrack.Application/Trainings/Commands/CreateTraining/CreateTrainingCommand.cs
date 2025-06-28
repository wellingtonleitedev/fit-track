using MediatR;
using ErrorOr;
using FitTrack.Domain.Trainings;

namespace FitTrack.Application.Trainings.Commands.CreateTraining;

public record CreateTrainingCommand(
    string Name,
    string? Category,
    DayTypes? Day,
    List<Guid> Exercises
) : IRequest<ErrorOr<Training>>;