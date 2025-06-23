namespace FitTrack.Contracts.Exercises;

public record CreateExerciseRequest(
    string Name,
    string Sets,
    string? Rest = null,
    string? Description = null
);