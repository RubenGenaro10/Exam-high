using practica_final_examen.API.Personnel.Domain.Model.Aggregates;
using practica_final_examen.API.Personnel.Domain.Model.Commands;
using practica_final_examen.API.Personnel.Domain.Repositories;
using practica_final_examen.API.Personnel.Domain.Services;
using practica_final_examen.API.Shared.Domain.Repositories;

namespace practica_final_examen.API.Personnel.Application.Internal.CommandService;

public class ExaminerCommandService(IExaminerRepository examinerRepository,IUnitOfWork unitOfWork):IExaminerCommandService
{
    public async Task<Examiner?> Handle(CreateExaminerCommand command)
    {
        var existsExaminer = examinerRepository.ExistsByNationalProviderIdentifier(command.NationalProviderIdentifier);
        if (existsExaminer)
        {
            throw new Exception("Examiner already exists");
        }
        var examiner = new Examiner(command);
        try
        {
            await examinerRepository.AddAsync(examiner);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
           return null;
        }

        return examiner;
    }
}