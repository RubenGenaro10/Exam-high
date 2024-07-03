using practica_final_examen.API.Personnel.Domain.Model.Commands;
using practica_final_examen.API.Personnel.Domain.Model.ValueObjects;

namespace practica_final_examen.API.Personnel.Domain.Model.Aggregates;

public partial class Examiner
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public NationalProviderIdentifier NationalProviderIdentifier { get; private set; }

    public Examiner()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        NationalProviderIdentifier = new NationalProviderIdentifier();
    }

    public Examiner(CreateExaminerCommand command)
    {
        FirstName = command.FirstName;
        LastName = command.LastName;
        NationalProviderIdentifier = new NationalProviderIdentifier(command.NationalProviderIdentifier);
    }
}