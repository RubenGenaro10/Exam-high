using practica_final_examen.API.Personnel.Domain.Model.Commands;
using practica_final_examen.API.Personnel.Interfaces.REST.Resources;

namespace practica_final_examen.API.Personnel.Interfaces.REST.Transform;

public class CreateExaminerCommandFromResourceAssembler
{
    public static CreateExaminerCommand ToCommandFromResource(CreateExaminerResource resource)
    {
        return new CreateExaminerCommand(resource.FirstName, resource.LastName, resource.NationalProviderIdentifier);
    }
}