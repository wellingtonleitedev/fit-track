using MediatR;
using FitTrack.Domain.Exercises;
using FitTrack.Application.Common.Interfaces;
using FitTrack.Api.Application.Exercises.Commands.CreateExercise;
using ErrorOr;

namespace FitTrack.Application.Exercises.Commands.CreateExercise;

public class CreateExerciseCommandHandler : IRequestHandler<CreateExerciseCommand, ErrorOr<Exercise>>
{
    private readonly IExerciseRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateExerciseCommandHandler(IExerciseRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Exercise>> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
    {
        var exercise = new Exercise
        {
            Name = request.Name,
            Sets = request.Sets,
            Rest = request.Rest,
            Description = request.Description
        };

        await _repository.AddAsync(exercise);
        await _unitOfWork.CommitChangesAsync();
        return exercise;
    }
}