using MediatR;
using ErrorOr;
using FitTrack.Domain.Trainings;
using FitTrack.Application.Common.Interfaces;


namespace FitTrack.Application.Trainings.Commands.CreateTraining;

public class CreateTrainingCommandHandler : IRequestHandler<CreateTrainingCommand, ErrorOr<Training>>
{
    private readonly ITrainingRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateTrainingCommandHandler(ITrainingRepository repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
    

    public async Task<ErrorOr<Training>> Handle(CreateTrainingCommand command, CancellationToken cancellationToken)
    {
        var training = new Training
        {
            Name = command.Name,
            Category = command.Category,
            Day = command.Day,
        };

        await _repository.AddAsync(training);
        await _unitOfWork.CommitChangesAsync();
        
        return training;
    }
}