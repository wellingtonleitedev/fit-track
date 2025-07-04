using FitTrack.Contracts.Exercises;

namespace FitTrack.Contracts.Trainings;

public record TrainingResponse(
    Guid Id,
    string Name,
    DayTypes? Day,
    List<ExerciseResponse> Exercises
);