using practica_final_examen.API.Personnel.Interfaces.ACL;

namespace practica_final_examen.API.Assessment.Application.Internal.OutboundServices.ACL;

public class ExternalExaminerService(IExaminerContextFacade examinerContextFacade)
{
    public async Task<int> FetchExaminerIdByNationalProviderIdentifier(Guid nationalProviderIdentifier)
    {
        return await examinerContextFacade.FetchExaminerIdByNationalProviderIdentifier(nationalProviderIdentifier);
    }

    public bool ExistsExaminerByNationalProviderIdentifier(Guid nationalProviderIdentifier)
    {
        return examinerContextFacade.ExistsExaminerByNationalProviderIdentifier(nationalProviderIdentifier);
    }
}