using System.ComponentModel.DataAnnotations;
using practica_final_examen.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace practica_final_examen.API.Personnel.Interfaces.REST.Resources;

public record CreateExaminerResource(
    string FirstName,
    string LastName,
    Guid NationalProviderIdentifier);