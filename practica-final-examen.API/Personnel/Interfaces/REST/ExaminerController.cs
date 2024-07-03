using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using practica_final_examen.API.Personnel.Domain.Services;
using practica_final_examen.API.Personnel.Interfaces.REST.Resources;
using practica_final_examen.API.Personnel.Interfaces.REST.Transform;

namespace practica_final_examen.API.Personnel.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ExaminerController(IExaminerCommandService examinerCommandService):ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateExaminer([FromBody] CreateExaminerResource resource)
    {
        var isUUID = Guid.TryParse(resource.NationalProviderIdentifier.ToString(), out _);
        if (!isUUID)
        {
            return BadRequest("UUID no válido");
        }
        var createExaminerCommand = CreateExaminerCommandFromResourceAssembler.ToCommandFromResource(resource);
        var examiner = await examinerCommandService.Handle(createExaminerCommand);
        if (examiner is null)
        {
            return BadRequest();
        }
        return Ok(ExaminerResourceFromEntityAssembler.ToResoureFromEntity(examiner));
        
    }
}