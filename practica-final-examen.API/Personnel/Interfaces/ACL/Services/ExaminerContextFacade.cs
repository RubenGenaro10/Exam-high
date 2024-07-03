using practica_final_examen.API.Personnel.Domain.Repositories;
using practica_final_examen.API.Personnel.Domain.Services;

namespace practica_final_examen.API.Personnel.Interfaces.ACL.Services;

public class ExaminerContextFacade(IExaminerCommandService examinerCommandService,IExaminerRepository examinerRepository): IExaminerContextFacade
{
    public async Task<int> FetchExaminerIdByNationalProviderIdentifier(Guid nationalProviderIdentifier)
    {
        var examiner = await examinerRepository.FindByNationalProviderIdentifier(nationalProviderIdentifier);
        if (examiner == null)
        {
            throw new Exception("Examiner not found");
        }

        return examiner.Id;
    }

    public bool ExistsExaminerByNationalProviderIdentifier(Guid nationalProviderIdentifier)
    {
        return examinerRepository.ExistsByNationalProviderIdentifier(nationalProviderIdentifier);
    }
}