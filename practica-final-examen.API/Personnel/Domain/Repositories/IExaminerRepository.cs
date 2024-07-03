using practica_final_examen.API.Personnel.Domain.Model.Aggregates;
using practica_final_examen.API.Shared.Domain.Repositories;

namespace practica_final_examen.API.Personnel.Domain.Repositories;

public interface IExaminerRepository : IBaseRepository<Examiner>
{
    Task<Examiner?> FindByNationalProviderIdentifier(Guid nationalProviderIdentifier);
    Task<Examiner?> FindById(int id);
    
    bool ExistsByNationalProviderIdentifier(Guid nationalProviderIdentifier);
}