using practica_final_examen.API.Assessment.Domain.Model.Aggregates;
using practica_final_examen.API.Assessment.Interfaces.REST.Resources;

namespace practica_final_examen.API.Assessment.Interfaces.REST.Transform;

public class MentalStateExamResourceFromEntityAssembler
{
    public static MentalStateExamResource ToResourceFromEntity(MentalStateExam exam)
    {
        return new MentalStateExamResource(exam.Id, exam.PatientId, exam.ExaminerNationalProviderIdentifier.Value, exam.ExamDate,
            exam.OrientationScore, exam.RegistrationScore, exam.AttentionAndCalculationScore, exam.RecallScore, exam.LanguageScore);
    }
}