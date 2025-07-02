using MediatR;
using ErrorOr;
using FitTrack.Domain.Trainings;
using FitTrack.Domain.Exercises;
using FitTrack.Application.Common.Interfaces;


namespace FitTrack.Application.Trainings.Commands.CreateTraining;

public class CreateTrainingCommandHandler : IRequestHandler<CreateTrainingCommand, ErrorOr<Training>>
{
    private readonly ITrainingRepository _trainingRepository;
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IExerciseTrainingRepository _exerciseTrainingRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTrainingCommandHandler(
        IUnitOfWork unitOfWork,
        ITrainingRepository trainingRepository,
        IExerciseRepository exerciseRepository,
        IExerciseTrainingRepository exerciseTrainingRepository
    )
    {
        _unitOfWork = unitOfWork;
        _trainingRepository = trainingRepository;
        _exerciseRepository = exerciseRepository;
        _exerciseTrainingRepository = exerciseTrainingRepository;
    }


    public async Task<ErrorOr<Training>> Handle(CreateTrainingCommand command, CancellationToken cancellationToken)
    {
        var exercises = await _exerciseRepository.GetListByIdAsync(command.Exercises);
        var training = new Training
        {
            Name = command.Name,
            Category = command.Category,
            Day = command.Day,
        };

        await _trainingRepository.AddAsync(training);
        await _exerciseTrainingRepository.AddRangeAsync(
            exercises.Select(exercise => new ExerciseTraining
            {
                ExerciseId = exercise.Id,
                TrainingId = training.Id,
            }).ToList()
        );

        await _unitOfWork.CommitChangesAsync();

        return training;
    }
}