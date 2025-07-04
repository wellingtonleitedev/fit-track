using FitTrack.Domain.Exercises;

namespace FitTrack.Domain.Workouts;

public class WorkoutRecord
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid WorkoutId { get; set; }
    public Workout Workout { get; set; } = null!;

    public Guid ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = null!;

    public int Reps { get; set; } = 0;
    public double Weight { get; set; } = 0.0;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}