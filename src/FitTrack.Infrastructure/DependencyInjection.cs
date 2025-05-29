using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FitTrack.Infrastructure.Common.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddDbContext<FitTrackDbContext>(options => options.UseSqlite("Data Source = FitTrack.db"));

        return services;
    }
}