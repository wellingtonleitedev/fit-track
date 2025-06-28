using System.Text.Json.Serialization;

namespace FitTrack.Domain.Trainings;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DayTypes
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday,
}