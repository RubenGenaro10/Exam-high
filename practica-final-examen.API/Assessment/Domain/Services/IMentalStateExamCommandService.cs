using practica_final_examen.API.Assessment.Domain.Model.Aggregates;
using practica_final_examen.API.Assessment.Domain.Model.Commands;

namespace practica_final_examen.API.Assessment.Domain.Services;

public interface IMentalStateExamCommandService
{
    Task<MentalStateExam?> Handle(CreateMentalStateExamCommand command);
}