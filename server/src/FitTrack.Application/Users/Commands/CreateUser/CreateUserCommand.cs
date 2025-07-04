using MediatR;
using ErrorOr;
using FitTrack.Domain.Users;

namespace FitTrack.Application.Users.Commands.CreateUser;

public record CreateUserCommand(string Name, string Email, string Password) : IRequest<ErrorOr<User>>;