using MediatR;
using Microsoft.AspNetCore.Mvc;
using FitTrack.Contracts.Exercises;
using FitTrack.Api.Application.Exercises.Commands.CreateExercise;

namespace FitTrack.Api.Controllers.Exercises;

[ApiController]
[Route("api/[controller]")]
public class ExercisesController : ControllerBase
{
    private readonly ISender _mediator;

    public ExercisesController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateExerciseRequest request)
    {
        var command = new CreateExerciseCommand(
            request.Name,
            request.Sets,
            request.Rest,
            request.Description
        );

        var result = await _mediator.Send(command);

        return result.MatchFirst(
            exercise => Ok(new ExerciseResponse(
                exercise.Id,
                exercise.Name,
                exercise.Sets,
                exercise.Rest,
                exercise.Description
            )),
            error => Problem()
        );
    }
}
