using FitTrack.Domain.Trainings;

namespace FitTrack.Domain.Exercises;

public class ExerciseTraining
{
    public Guid Id { get; set; }
    public Guid ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = null!;

    public Guid TrainingId { get; set; }
    public Training Training { get; set; } = null!;

    public int? Order { get; set; } = 0;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}