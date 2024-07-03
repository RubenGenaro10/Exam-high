using System.ComponentModel.DataAnnotations;

namespace practica_final_examen.API.Assessment.Domain.Model.Commands;

public record CreateMentalStateExamCommand(
    int PatientId, 
    Guid ExaminerNationalProviderIdentifier,
    DateTime ExamDate, 
    int OrientationScore,
    int RegistrationScore,
    int AttentionAndCalculationScore,
    int RecallScore, 
    int LanguageScore);