using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using practica_final_examen.API.Assessment.Domain.Services;
using practica_final_examen.API.Assessment.Interfaces.REST.Resources;
using practica_final_examen.API.Assessment.Interfaces.REST.Transform;

namespace practica_final_examen.API.Assessment.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class MentalStateExamController(IMentalStateExamCommandService mentalStateExamCommandService):ControllerBase
{
 [HttpPost]
 public async Task<IActionResult> CreateMentalStateExam([FromBody] CreateMentalStateExamResource resource)
 {
     if(!ModelState.IsValid)
     {
         return BadRequest(ModelState);
     }
     var createMentalStateExamCommand = CreateMentalStateExamCommandFromResourceAssembler.ToCommandFromResource(resource);
     try
     {
         var exam = await mentalStateExamCommandService.Handle(createMentalStateExamCommand);

         if (exam is null)
         {
             return BadRequest();
         }

         return Ok(MentalStateExamResourceFromEntityAssembler.ToResourceFromEntity(exam));
     }
     catch (ValidationException ex)
     {
         return BadRequest(new { message = ex.Message });
     }
 }
}