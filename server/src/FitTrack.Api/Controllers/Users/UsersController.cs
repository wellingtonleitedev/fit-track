
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FitTrack.Contracts.Users;
using FitTrack.Application.Users.Commands.CreateUser;

namespace FitTrack.Api.Controllers.Users;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ISender _mediator;

    public UsersController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest request)
    {
        var command = new CreateUserCommand(request.Name, request.Email, request.Password);
        
        var result = await _mediator.Send(command);

        return result.MatchFirst(
            user => Ok(new UserResponse(user.Id, user.Name, user.Email)),
            error => Problem()
        );
    }
}
