using practica_final_examen.API.Assessment.Domain.Model.Commands;
using practica_final_examen.API.Assessment.Interfaces.REST.Resources;
using practica_final_examen.API.Personnel.Domain.Model.Commands;

namespace practica_final_examen.API.Assessment.Interfaces.REST.Transform;

public class CreateMentalStateExamCommandFromResourceAssembler
{
    /**
     * int PatientId, 
    Guid ExaminerNationalProviderIdentifier, DateTime ExamDate, 
    int OrientationScore, int RegistrationScore, int AttentionAndCalculationScore, 
    int RecallScore, int LanguageScore
     */
    public static CreateMentalStateExamCommand ToCommandFromResource(CreateMentalStateExamResource resource)
    {
        return new CreateMentalStateExamCommand(resource.PatientId,resource.ExaminerNationalProviderIdentifier,resource.ExamDate,resource.OrientationScore,
            resource.RegistrationScore,resource.AttentionAndCalculationScore,resource.RecallScore,resource.LanguageScore);
    }
}