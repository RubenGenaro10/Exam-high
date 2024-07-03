using Microsoft.EntityFrameworkCore;
using practica_final_examen.API.Personnel.Domain.Model.Aggregates;
using practica_final_examen.API.Personnel.Domain.Repositories;
using practica_final_examen.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using practica_final_examen.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace practica_final_examen.API.Personnel.Infrastructure.Persistence.EFC.Repositories;

internal class ExaminerRepository : BaseRepository<Examiner>, IExaminerRepository
{
    public ExaminerRepository(AppDbContext context): base(context)
    {
    }

    public async Task<Examiner?> FindByNationalProviderIdentifier(Guid nationalProviderIdentifier)
    {
        return await Context.Set<Examiner>().FirstOrDefaultAsync(f=>f.NationalProviderIdentifier.Value == nationalProviderIdentifier);
    }

    public async Task<Examiner?> FindById(int id)
    {
        return await Context.Set<Examiner>().FirstOrDefaultAsync(f=>f.Id == id);
    }

    public  bool ExistsByNationalProviderIdentifier(Guid nationalProviderIdentifier)
    {
        return Context.Set<Examiner>().AsEnumerable().Any(f => f.NationalProviderIdentifier.Value == nationalProviderIdentifier);
    }
}