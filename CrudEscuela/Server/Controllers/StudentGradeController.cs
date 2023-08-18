using CrudEscuela.Server.Commands.Contracts;
using CrudEscuela.Shared.StudentGrade;
using CrudEscuela.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CrudEscuela.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentGradeController : ControllerBase
{
    private readonly static string _successGetAllMessage = "Se han devuelto todos los grados de estudiantes";
    private readonly static string _successGetStudentGradeMessage = "Se ha devuelto el grados del estudiante";
    private readonly static string _errorGetAllMessage = "Ocurrio un error al devolver todos los grados de estudiantes";
    private readonly static string _errorGetStudentGradeMessage = "Ocurrio un error al devolver al grados de estudiantes";
    private readonly static string _successsCreateStudentGradeMessage = "Se ha creado al grado de estudiante correctamente";
    private readonly static string _errorCreateStudentGradeMessage = "Algo ha salido mal al crear grado de estudiante";
    private readonly static string _successUpdateStudentGradeMessage = "El grado de estudiante se ha actualizado corectamente";
    private readonly static string _errorUpdateStudentGradeMessage = "Algo ha salido mal al actualizar al grado de estudiante";
    private readonly static string _successDeleteStudentGradeMessage = "El grado de estudiante se ha removido correctamente";
    private readonly static string _errorDeleteStudentGradeMessage = "Algo ha salido mal al remover grado de estudiante";

    private readonly IStudentGradeCommands _studentGradeCommands;
    private readonly ILogger<StudentGradeController> _logger;

    public StudentGradeController(IStudentGradeCommands studentGradeCommands, ILogger<StudentGradeController> logger)
    {
        _studentGradeCommands = studentGradeCommands;
        _logger = logger;
    }


    [HttpGet("getAll")]
    public async Task<ActionResult<ServiceResponse<GetAllStudentGradeResponse>>> GetAll()
    {
        var response = new ServiceResponse<GetAllStudentGradeResponse>();

        try
        {
            var studentGrades = await _studentGradeCommands.GetAllStudentGrades();
            response.Success = true;
            response.Message = _successGetAllMessage;
            response.Data = new GetAllStudentGradeResponse { StudentGrades = studentGrades.Select(sg => sg.ToDefinition()).ToList() };
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Something went wrong while fetching student grades");
            response.Success = false;
            response.Message = _errorGetAllMessage;
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }

    [HttpGet("getStudentGrade/{id}")]
    public async Task<ActionResult<ServiceResponse<GetStudentGradeResponse>>> GetStudentGrade(string id)
    {
        var response = new ServiceResponse<GetStudentGradeResponse>();

        try
        {
            var studentGrade = await _studentGradeCommands.GetStudentGradeById(Guid.Parse(id));
            response.Success = true;
            response.Message = _successGetStudentGradeMessage;
            response.Data = new GetStudentGradeResponse { StudentGrade = studentGrade.ToDefinition() };
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Something went wrong while fetching student grade by id");
            response.Success = false;
            response.Message = _errorGetStudentGradeMessage;
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }

    [HttpPost("createStudentGrade")]
    public async Task<ActionResult<ServiceResponse<CreateStudentGradeRequest>>> CreateStudentGrade(CreateStudentGradeRequest request)
    {
        var response = new ServiceResponse<CreateStudentGradeResponse>();

        try
        {
            var studentGrade = await _studentGradeCommands.CreateStudentGrade(request);
            response.Success = true;
            response.Message = _successsCreateStudentGradeMessage;
            response.Data = new CreateStudentGradeResponse { StudentGrade = studentGrade.ToDefinition() };
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Something went wrong while creating student grade");
            response.Success = false;
            response.Message = _errorCreateStudentGradeMessage;
            return BadRequest(response);
        }
    }

    [HttpPut("updateStudentGrade")]
    public async Task<ActionResult<ServiceResponse<UpdateStudentGradeResponse>>> UpdateStudentGrade(UpdateStudentGradeRequest request)
    {
        var response = new ServiceResponse<UpdateStudentGradeResponse>();

        try
        {
            var studentGrade = await _studentGradeCommands.UpdateStudentGrade(request);
            response.Success = true;
            response.Message = _successUpdateStudentGradeMessage;
            response.Data = new UpdateStudentGradeResponse { StudentGrade = studentGrade.ToDefinition() };
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Something went wrong updating StudentGrade");
            response.Success = false;
            response.Message = _errorUpdateStudentGradeMessage;
            return BadRequest(response);
        }
    }

    [HttpDelete("deleteStudentGrade")]
    public async Task<ActionResult<ServiceResponse<UpdateStudentGradeResponse>>> DeleteStudentGrade(DeleteStudentGradeRequest request)
    {
        var response = new ServiceResponse<UpdateStudentGradeResponse>();
        try
        {
            var studentGrade = await _studentGradeCommands.DeleteStudentGrade(request);
            response.Success = true;
            response.Message = _successDeleteStudentGradeMessage;
            response.Data = new UpdateStudentGradeResponse { StudentGrade = studentGrade.ToDefinition() };
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Something went wrong remove StudentGrade");
            response.Success = false;
            response.Message = _errorDeleteStudentGradeMessage;
            return BadRequest(response);
        }
    }
}
