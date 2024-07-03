namespace practica_final_examen.API.Personnel.Interfaces.ACL;

public interface IExaminerContextFacade
{
    Task<int> FetchExaminerIdByNationalProviderIdentifier(Guid nationalProviderIdentifier);
    bool ExistsExaminerByNationalProviderIdentifier(Guid nationalProviderIdentifier);
}