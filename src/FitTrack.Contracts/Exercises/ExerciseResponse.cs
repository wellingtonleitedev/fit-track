namespace FitTrack.Contracts.Exercises;

public record ExerciseResponse(
    Guid Id,
    string Name,
    string Sets,
    string? Rest = null,
    string? Description = null
);