using Microsoft.EntityFrameworkCore;
using FitTrack.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using FitTrack.Infrastructure.Users.Persistence;
using FitTrack.Infrastructure.Common.Persistence;
using FitTrack.Infrastructure.Exercises.Persistence;
using FitTrack.Infrastructure.Trainings.Persistence;
using FitTrack.Infrastructure.Workouts.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IWorkoutRepository, WorkoutRepository>();
        services.AddScoped<IExerciseRepository, ExerciseRepository>();
        services.AddScoped<ITrainingRepository, TrainingRepository>();
        services.AddScoped<IWorkoutRecordRepository, WorkoutRecordRepository>();
        services.AddDbContext<FitTrackDbContext>(options => options.UseSqlite("Data Source = FitTrack.db"));
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<FitTrackDbContext>());

        return services;
    }
}