using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace practica_final_examen.API.Personnel.Domain.Model.ValueObjects;

public record NationalProviderIdentifier(Guid Value)
{
    public NationalProviderIdentifier()
        : this(Guid.NewGuid()) // Genera un UUID válido por defecto
    {
    }
}

public class NationalProviderIdentifierConverter : ValueConverter<NationalProviderIdentifier, Guid>
{
    public NationalProviderIdentifierConverter()
        : base(
            npid => npid.Value,
            guid => new NationalProviderIdentifier(guid))
    {
    }
}