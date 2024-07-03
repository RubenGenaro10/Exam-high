namespace practica_final_examen.API.Personnel.Domain.Model.Commands;

public record CreateExaminerCommand(string FirstName, string LastName, Guid NationalProviderIdentifier);