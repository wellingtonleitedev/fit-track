using MediatR;
using ErrorOr;
using FitTrack.Domain.Users;
using FitTrack.Application.Common.Interfaces;

namespace FitTrack.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<User>>
{
    private readonly IUserRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUserRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<User>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = new User {
            Name = command.Name,
            Email = command.Email,
            Password = command.Password,
        };

        await _repository.AddAsync(user);
        await _unitOfWork.CommitChangesAsync();

        return user;
    }
}