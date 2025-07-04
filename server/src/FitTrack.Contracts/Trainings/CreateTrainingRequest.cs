namespace FitTrack.Contracts.Trainings;

public enum DayTypes
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

public record CreateTrainingRequest(
    string Name,
    string? Category,
    DayTypes? Day,
    List<Guid> Exercises
);