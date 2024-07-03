using practica_final_examen.API.Personnel.Domain.Model.Aggregates;
using practica_final_examen.API.Personnel.Domain.Model.Commands;

namespace practica_final_examen.API.Personnel.Domain.Services;

public interface IExaminerCommandService
{
    Task<Examiner?> Handle(CreateExaminerCommand command);
}