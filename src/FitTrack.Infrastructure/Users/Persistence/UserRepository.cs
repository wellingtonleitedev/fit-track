using FitTrack.Domain.Users;
using FitTrack.Application.Common.Interfaces;
using FitTrack.Infrastructure.Common.Persistence;

namespace FitTrack.Infrastructure.Users.Persistence;

public class UserRepository : IUserRepository
{
    private readonly FitTrackDbContext _dbContext;

    public UserRepository(FitTrackDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(User user)
    {
        await _dbContext.AddAsync(user);
    }
}