namespace practica_final_examen.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}