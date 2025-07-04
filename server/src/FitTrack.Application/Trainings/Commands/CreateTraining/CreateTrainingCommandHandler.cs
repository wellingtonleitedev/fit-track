using MediatR;
using ErrorOr;
using FitTrack.Domain.Trainings;
using FitTrack.Application.Common.Interfaces;


namespace FitTrack.Application.Trainings.Commands.CreateTraining;

public class CreateTrainingCommandHandler : IRequestHandler<CreateTrainingCommand, ErrorOr<Training>>
{
    private readonly ITrainingRepository _trainingRepository;
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTrainingCommandHandler(ITrainingRepository trainingRepository, IExerciseRepository exerciseRepository, IUnitOfWork unitOfWork)
    {
        _trainingRepository = trainingRepository;
        _exerciseRepository = exerciseRepository;
        _unitOfWork = unitOfWork;
    }
    

    public async Task<ErrorOr<Training>> Handle(CreateTrainingCommand command, CancellationToken cancellationToken)
    {
        var exercises = await _exerciseRepository.GetListByIdAsync(command.Exercises);
        var training = new Training
        {
            Name = command.Name,
            Day = command.Day,
            Exercises = exercises
        };

        await _trainingRepository.AddAsync(training);
        await _unitOfWork.CommitChangesAsync();
        
        return training;
    }
}