using MediatR;
using Microsoft.AspNetCore.Mvc;
using FitTrack.Contracts.Exercises;
using FitTrack.Contracts.Trainings;
using FitTrack.Application.Trainings.Commands.CreateTraining;

namespace FitTrack.Api.Controllers.Trainings;

[ApiController]
[Route("api/[controller]")]
public class TrainingsController : ControllerBase
{
    private readonly ISender _mediator;

    public TrainingsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTrainingRequest request)
    {
        var command = new CreateTrainingCommand(request.Name, (Domain.Trainings.DayTypes?)request.Day, request.Exercises);

        var result = await _mediator.Send(command);

        return result.MatchFirst(
            training => Ok(
                new TrainingResponse(
                    training.Id,
                    training.Name,
                    (DayTypes?)training.Day,
                    training.Exercises.Select(e =>
                        new ExerciseResponse(
                            e.Id,
                            e.Name,
                            e.Sets,
                            e.Rest,
                            e.Description
                        )
                    ).ToList()
                )),
            error => Problem()
        );
    }
}