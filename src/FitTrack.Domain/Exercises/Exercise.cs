using FitTrack.Domain.Trainings;
using FitTrack.Domain.TrainingExercises;

namespace FitTrack.Domain.Exercises;

public class Exercise
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public string Sets { get; set; } = string.Empty;
    public string? Rest { get; set; }
    public string? Description { get; set; }
    public List<Training> Trainings { get; set; } = [];
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public ICollection<TrainingExercise> TrainingExercise { get; set; } = [];
}