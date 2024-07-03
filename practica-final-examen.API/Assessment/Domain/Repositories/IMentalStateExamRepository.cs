using practica_final_examen.API.Assessment.Domain.Model.Aggregates;
using practica_final_examen.API.Shared.Domain.Repositories;

namespace practica_final_examen.API.Assessment.Domain.Repositories;

public interface IMentalStateExamRepository : IBaseRepository<MentalStateExam>
{
    Task<MentalStateExam?> FindByExaminerNationalProviderIdentifier(Guid nationalProviderIdentifier);
}