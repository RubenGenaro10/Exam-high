using System.ComponentModel.DataAnnotations;
using practica_final_examen.API.Assessment.Domain.Model.Commands;
using practica_final_examen.API.Personnel.Domain.Model.ValueObjects;

namespace practica_final_examen.API.Assessment.Domain.Model.Aggregates;

public class MentalStateExam
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public NationalProviderIdentifier  ExaminerNationalProviderIdentifier { get; private set; }
    [Required]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [CustomValidation(typeof(MentalStateExam), nameof(ValidateExamDate))]
    public DateTime ExamDate { get; set; }
    
    [Range(0, 10, ErrorMessage = "OrientationScore debe estar entre 0 y 10.")]
    public int OrientationScore { get; set; }
    [Range(0, 3, ErrorMessage = "RegistrationScore debe estar entre 0 y 3.")]
    public int RegistrationScore { get; set; }

    [Range(0, 5, ErrorMessage = "AttentionAndCalculationScore debe estar entre 0 y 5.")]
    public int AttentionAndCalculationScore { get; set; }

    [Range(0, 3, ErrorMessage = "RecallScore debe estar entre 0 y 3.")]
    public int RecallScore { get; set; }

    [Range(0, 9, ErrorMessage = "LanguageScore debe estar entre 0 y 9.")]
    public int LanguageScore { get; set; }

    public MentalStateExam()
    {
        ExaminerNationalProviderIdentifier = new NationalProviderIdentifier();
    }

    public MentalStateExam(CreateMentalStateExamCommand command)
    {
        ExaminerNationalProviderIdentifier = new NationalProviderIdentifier(command.ExaminerNationalProviderIdentifier);
        PatientId = command.PatientId;
        ExamDate = command.ExamDate;
        OrientationScore = command.OrientationScore;
        RegistrationScore = command.RegistrationScore;
        AttentionAndCalculationScore = command.AttentionAndCalculationScore;
        RecallScore = command.RecallScore;
        LanguageScore = command.LanguageScore;
    }
    
    public static ValidationResult? ValidateExamDate(DateTime examDate, ValidationContext context)
    {
        if (examDate > DateTime.Now)
        {
            return new ValidationResult("ExamDate no puede ser una fecha futura.");
        }
        return ValidationResult.Success;
    }
}