using Microsoft.EntityFrameworkCore;
using practica_final_examen.API.Assessment.Application.Internal.CommandService;
using practica_final_examen.API.Assessment.Application.Internal.OutboundServices.ACL;
using practica_final_examen.API.Assessment.Domain.Repositories;
using practica_final_examen.API.Assessment.Domain.Services;
using practica_final_examen.API.Assessment.Infrastructure.Persistence.EFC.Repositories;
using practica_final_examen.API.Personnel.Application.Internal.CommandService;
using practica_final_examen.API.Personnel.Domain.Repositories;
using practica_final_examen.API.Personnel.Domain.Services;
using practica_final_examen.API.Personnel.Infrastructure.Persistence.EFC.Repositories;
using practica_final_examen.API.Personnel.Interfaces.ACL;
using practica_final_examen.API.Personnel.Interfaces.ACL.Services;
using practica_final_examen.API.Shared.Domain.Repositories;
using practica_final_examen.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using practica_final_examen.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using practica_final_examen.API.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
builder.Services.AddRouting(options => options.LowercaseUrls = true);



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Configure Database Context and Logging Level
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString != null)
        if (builder.Environment.IsDevelopment())
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        else if (builder.Environment.IsProduction())
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Error)
                .EnableDetailedErrors();
});

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// News Bounded Context Injection Configuration
// Aqui se inyectan los servicios de bounded context
/*
builder.Services.AddScoped<IFavoriteSourceRepository, FavoriteSourceRepository>();
builder.Services.AddScoped<IFavoriteSourceCommandService, FavoriteSourceCommandService>();
builder.Services.AddScoped<IFavoriteSourceQueryService, FavoriteSourceQueryService>();
*/

//Examiner Bounded Context Injection Configuration
builder.Services.AddScoped<IExaminerRepository, ExaminerRepository>();
builder.Services.AddScoped<IExaminerCommandService, ExaminerCommandService>();
builder.Services.AddScoped<IExaminerContextFacade, ExaminerContextFacade>();
builder.Services.AddScoped<ExternalExaminerService>();

//MentalStateExam Bounded Context Injection Configuration
builder.Services.AddScoped<IMentalStateExamRepository, MentalStateExamRepository>();
builder.Services.AddScoped<IMentalStateExamCommandService, MentalStateExamCommandService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Verify Database Objects are Created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();