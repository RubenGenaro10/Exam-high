using practica_final_examen.API.Shared.Domain.Repositories;
using practica_final_examen.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace practica_final_examen.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }
}