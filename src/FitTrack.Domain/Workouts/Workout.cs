using FitTrack.Domain.Trainings;

namespace FitTrack.Domain.Workouts;

public class Workout
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TrainingId { get; set; }
    public Training Training { get; set; } = null!;
    public DateTime? EndDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public ICollection<WorkoutRecord> Records { get; set; } = [];
}