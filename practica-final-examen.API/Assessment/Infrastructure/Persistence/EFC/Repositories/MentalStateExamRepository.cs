using Microsoft.EntityFrameworkCore;
using practica_final_examen.API.Assessment.Domain.Model.Aggregates;
using practica_final_examen.API.Assessment.Domain.Repositories;
using practica_final_examen.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using practica_final_examen.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace practica_final_examen.API.Assessment.Infrastructure.Persistence.EFC.Repositories;

public class MentalStateExamRepository : BaseRepository<MentalStateExam> ,IMentalStateExamRepository
{
    public MentalStateExamRepository(AppDbContext context): base(context)
    {
    }

    public async Task<MentalStateExam?> FindByExaminerNationalProviderIdentifier(Guid nationalProviderIdentifier)
    {
        return  await Context.Set<MentalStateExam>().FirstOrDefaultAsync(f=>f.ExaminerNationalProviderIdentifier.Value == nationalProviderIdentifier);
    }
}