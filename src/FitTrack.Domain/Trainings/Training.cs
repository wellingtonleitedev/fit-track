using FitTrack.Domain.Exercises;

namespace FitTrack.Domain.Trainings;

public class Training {
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string? Category { get; set; } = string.Empty;
    public DayTypes? Day { get; set; } = DayTypes.Monday;
    public List<Exercise> Exercises { get; set; } = [];
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}