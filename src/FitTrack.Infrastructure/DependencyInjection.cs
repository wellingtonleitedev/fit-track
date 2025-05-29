using Microsoft.EntityFrameworkCore;
using FitTrack.Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using FitTrack.Infrastructure.Users.Persistence;
using FitTrack.Infrastructure.Common.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddDbContext<FitTrackDbContext>(options => options.UseSqlite("Data Source = FitTrack.db"));
        services.AddScoped<IUnitOfWork>(provider => provider.GetRequiredService<FitTrackDbContext>());

        return services;
    }
}