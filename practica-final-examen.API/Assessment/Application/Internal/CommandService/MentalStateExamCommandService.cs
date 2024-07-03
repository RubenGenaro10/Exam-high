using System.ComponentModel.DataAnnotations;
using practica_final_examen.API.Assessment.Application.Internal.OutboundServices.ACL;
using practica_final_examen.API.Assessment.Domain.Model.Aggregates;
using practica_final_examen.API.Assessment.Domain.Model.Commands;
using practica_final_examen.API.Assessment.Domain.Repositories;
using practica_final_examen.API.Assessment.Domain.Services;
using practica_final_examen.API.Personnel.Interfaces.ACL;
using practica_final_examen.API.Shared.Domain.Repositories;

namespace practica_final_examen.API.Assessment.Application.Internal.CommandService;

public class MentalStateExamCommandService(IMentalStateExamRepository mentalStateExamRepository,IUnitOfWork unitOfWork,ExternalExaminerService externalExaminerService):IMentalStateExamCommandService
{
    public async Task<MentalStateExam?> Handle(CreateMentalStateExamCommand command)
    {
        var existsExaminer = externalExaminerService.ExistsExaminerByNationalProviderIdentifier(command.ExaminerNationalProviderIdentifier);
        if (!existsExaminer)
        {
            throw new Exception("Este examinador no existe");
        }
        var mentalStateExam = new MentalStateExam(command);
        //validations
        var validationContext = new ValidationContext(mentalStateExam);
        Validator.ValidateObject(mentalStateExam, validationContext, validateAllProperties: true);
        try
        {
            await mentalStateExamRepository.AddAsync(mentalStateExam);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
           return null;
        }
        return mentalStateExam;
    }
}