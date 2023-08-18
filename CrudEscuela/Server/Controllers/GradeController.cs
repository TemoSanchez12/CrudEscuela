using CrudEscuela.Server.Commands.Contracts;
using CrudEscuela.Shared;
using Microsoft.AspNetCore.Mvc;
using CrudEscuela.Shared.Grade;

namespace CrudEscuela.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GradeController : ControllerBase
{
    private readonly static string _successGetAllMessage = "Se han devuelto todos los grados";
    private readonly static string _successGetGradeMessage = "Se ha devuelto el grados";
    private readonly static string _errorGetAllMessage = "Ocurrio un error al devolver todos los grados";
    private readonly static string _errorGetGradeMessage = "Ocurrio un error al devolver al grados";
    private readonly static string _successsCreateGradeMessage = "Se ha creado al grade correctamente";
    private readonly static string _errorCreateGradeMessage = "Algo ha salido mal al crear grado";
    private readonly static string _successUpdateGradeMessage = "El grado se ha actualizado corectamente";
    private readonly static string _errorUpdateGradeMessage = "Algo ha salido mal al actualizar al grado";
    private readonly static string _successDeleteGradeMessage = "El grado se ha removido correctamente";
    private readonly static string _errorDeleteGradeMessage = "Algo ha salido mal al remover grado";

    private readonly IGradeCommands _gradeCommands;
    private readonly ILogger<GradeController> _logger;

    public GradeController(IGradeCommands gradeCommands, ILogger<GradeController> logger)
    {
        _gradeCommands = gradeCommands;
        _logger = logger;
    }


    [HttpGet("getAll")]
    public async Task<ActionResult<ServiceResponse<GetAllGradesResponse>>> GetAll()
    {
        var response = new ServiceResponse<GetAllGradesResponse>();

        try
        {
            var grades = await _gradeCommands.GetAllGrades();
            response.Success = true;
            response.Message = _successGetAllMessage;
            response.Data = new GetAllGradesResponse { Grades = grades.Select(grade => grade.ToDefinition()).ToList() };
            return Ok(response);
        }
        catch ( Exception ex )
        {
            _logger.LogError(ex, "Something went wrong while fetching grades");
            response.Success = false;
            response.Message = _errorGetAllMessage;
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }

    [HttpGet("getGrade/{id}")]
    public async Task<ActionResult<ServiceResponse<GetGradeResponse>>> GetStudent(string id)
    {
        var response = new ServiceResponse<GetGradeResponse>();

        try
        {
            var grade = await _gradeCommands.GetGradeById(Guid.Parse(id));
            response.Success = true;
            response.Message = _successGetGradeMessage;
            response.Data = new GetGradeResponse { Grade = grade.ToDefinition() };
            return Ok(response);
        }
        catch ( Exception ex )
        {
            _logger.LogError(ex, "Something went wrong while fetching grade by id");
            response.Success = false;
            response.Message = _errorGetGradeMessage;
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }

    [HttpPost("createGrade")]
    public async Task<ActionResult<ServiceResponse<CreateGradeRequest>>> CreateStudent(CreateGradeRequest request)
    {
        var response = new ServiceResponse<CreateGradeResponse>();

        try
        {
            var grade = await _gradeCommands.CreateGrade(request);
            response.Success = true;
            response.Message = _successsCreateGradeMessage;
            response.Data = new CreateGradeResponse { Grade = grade.ToDefinition() };
            return Ok(response);
        }
        catch ( Exception ex )
        {
            _logger.LogError(ex, "Something went wrong while creating grade");
            response.Success = false;
            response.Message = _errorCreateGradeMessage;
            return BadRequest(response);
        }
    }

    [HttpPut("updateGrade")]
    public async Task<ActionResult<ServiceResponse<UpdateGradeResponse>>> UpdateGrade(UpdateGradeRequest request)
    {
        var response = new ServiceResponse<UpdateGradeResponse>();

        try
        {
            var grade = await _gradeCommands.UpdateGrade(request);
            response.Success = true;
            response.Message = _successUpdateGradeMessage;
            response.Data = new UpdateGradeResponse { Grade = grade.ToDefinition() };
            return Ok(response);
        }
        catch ( Exception ex )
        {
            _logger.LogError(ex, "Something went wrong updating grade");
            response.Success = false;
            response.Message = _errorUpdateGradeMessage;
            return BadRequest(response);
        }
    }

    [HttpDelete("deleteGrade")]
    public async Task<ActionResult<ServiceResponse<DeleteGradeResponse>>> DeleteGrade(DeleteGradeRequest request)
    {
        var response = new ServiceResponse<DeleteGradeResponse>();
        try
        {
            var grade = await _gradeCommands.DeleteGrade(request);
            response.Success = true;
            response.Message = _successDeleteGradeMessage;
            response.Data = new DeleteGradeResponse { Grade = grade.ToDefinition() };
            return Ok(response);
        }
        catch ( Exception ex )
        {
            _logger.LogError(ex, "Something went wrong remove grade");
            response.Success = false;
            response.Message = _errorDeleteGradeMessage;
            return BadRequest(response);
        }
    }
}
