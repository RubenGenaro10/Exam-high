using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using practica_final_examen.API.Assessment.Domain.Model.Aggregates;
using practica_final_examen.API.Personnel.Domain.Model.Aggregates;
using practica_final_examen.API.Personnel.Domain.Model.ValueObjects;
using practica_final_examen.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace practica_final_examen.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    // agrega un interceptor para que se actualicen las fechas de creación y actualización
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        builder.AddCreatedUpdatedInterceptor();
    }

    // Configuración de las tablas de la base de datos
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //Configuración de los modelos de la base de datos
      
        //Examiner Context
        builder.Entity<Examiner>().ToTable("Examiners");
        builder.Entity<Examiner>().HasKey(e => e.Id);
        builder.Entity<Examiner>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Examiner>().Property(e => e.FirstName).IsRequired().HasMaxLength(50);
        builder.Entity<Examiner>().Property(e => e.LastName).IsRequired().HasMaxLength(50);
        builder.Entity<Examiner>()
            .Property(e => e.NationalProviderIdentifier)
            .IsRequired()
            .HasConversion(new NationalProviderIdentifierConverter())
            .HasMaxLength(50);
        
        // MentalStateExam Context
        builder.Entity<MentalStateExam>().ToTable("MentalStateExams");
        builder.Entity<MentalStateExam>().HasKey(e => e.Id);
        builder.Entity<MentalStateExam>().Property(e => e.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<MentalStateExam>().Property(e => e.PatientId).IsRequired();
        builder.Entity<MentalStateExam>().Property(e => e.ExamDate).IsRequired();
        builder.Entity<MentalStateExam>().Property(e => e.OrientationScore).IsRequired();
        builder.Entity<MentalStateExam>().Property(e => e.RegistrationScore).IsRequired();
        builder.Entity<MentalStateExam>().Property(e => e.AttentionAndCalculationScore).IsRequired();
        builder.Entity<MentalStateExam>().Property(e => e.RecallScore).IsRequired();
        builder.Entity<MentalStateExam>().Property(e => e.LanguageScore).IsRequired();
        builder.Entity<MentalStateExam>()
            .Property(e => e.ExaminerNationalProviderIdentifier)
            .IsRequired()
            .HasConversion(new NationalProviderIdentifierConverter())
            .HasMaxLength(50);
        
        // aplica la convención de nombres snake_case
        builder.UseSnakeCaseNamingConvention();

    }
}