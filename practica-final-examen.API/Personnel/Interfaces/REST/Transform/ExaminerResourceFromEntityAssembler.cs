using practica_final_examen.API.Personnel.Domain.Model.Aggregates;
using practica_final_examen.API.Personnel.Interfaces.REST.Resources;

namespace practica_final_examen.API.Personnel.Interfaces.REST.Transform;

public class ExaminerResourceFromEntityAssembler
{
    public static ExaminerResource ToResoureFromEntity(Examiner examiner)
    {
        return new ExaminerResource(examiner.Id, examiner.FirstName, examiner.LastName, examiner.NationalProviderIdentifier.Value);
    }
}