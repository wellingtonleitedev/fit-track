using FitTrack.Contracts.Exercises;

namespace FitTrack.Contracts.Trainings;

public record TrainingResponse(
    Guid Id,
    string Name,
    string? Category,
    DayTypes? Day,
    List<ExerciseResponse> Exercises
);