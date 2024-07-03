namespace practica_final_examen.API.Assessment.Interfaces.REST.Resources;

public record MentalStateExamResource(int Id, int PatientId, 
    Guid ExaminerNationalProviderIdentifier, DateTime ExamDate, 
    int OrientationScore, int RegistrationScore, int AttentionAndCalculationScore, 
    int RecallScore, int LanguageScore);