namespace FitTrack.Contracts.Workouts;

public record ExerciseRecord(
    Guid Id,
    int Reps,
    double Weight
);

public record UpdateWorkoutRequest(List<ExerciseRecord> Records);