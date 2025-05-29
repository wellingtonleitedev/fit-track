using FitTrack.Domain.Users;

namespace FitTrack.Application.Common.Interfaces;

public interface IUserRepository
{
    Task AddAsync(User user);
}