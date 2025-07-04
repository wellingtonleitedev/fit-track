namespace FitTrack.Contracts.Users;

public record CreateUserRequest(string Name, string Email, string Password);