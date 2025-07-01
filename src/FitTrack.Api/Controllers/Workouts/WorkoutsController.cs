using MediatR;
using Microsoft.AspNetCore.Mvc;
using FitTrack.Contracts.Workouts;
using FitTrack.Application.Workouts.Commands;

namespace FitTrack.Api.Controllers.Workouts;

[ApiController]
[Route("api/[controller]")]
public class WorkoutsController : ControllerBase
{
    private readonly ISender _mediator;

    public WorkoutsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateWorkoutRequest request)
    {
        var command = new CreateWorkoutCommand(request.TrainingId);
        var result = await _mediator.Send(command);

        return result.MatchFirst<IActionResult>(
            workout => Ok(),
            errors => Problem()
        );
    }
}