using CrudEscuela.Server.Commands.Contracts;
using CrudEscuela.Shared.Student;
using CrudEscuela.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CrudEscuela.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly static string _successGetAllMessage = "Se han devuelto todos los estudiantes";
    private readonly static string _successGetStudentMessage = "Se ha devuelto el estudiante";
    private readonly static string _errorGetAllMessage = "Ocurrio un error al devolver todos los estudiantes";
    private readonly static string _errorGetStudentMessage = "Ocurrio un error al devolver al estudiante";
    private readonly static string _successsCreateStudentMessage = "Se ha creado el estudiante correctamente";
    private readonly static string _errorCreateStudentMessage = "Algo ha salido mal al crear estudiante";
    private readonly static string _successUpdateStudentMessage = "El estudiante se ha actualizado corectamente";
    private readonly static string _errorUpdateStudentMessage = "Algo ha salido mal al actualizar al estudiante";
    private readonly static string _successDeleteStudentMessage = "El estudiante se ha removido correctamente";
    private readonly static string _errorDeleteStudentMessage = "Algo ha salido mal al remover estudiante";

    private readonly IStudentCommands _studentCommands;
    private readonly ILogger<StudentController> _logger;

    public StudentController(IStudentCommands studentCommands, ILogger<StudentController> logger)
    {
        _logger = logger;
        _studentCommands = studentCommands;
    }

    [HttpGet("getAll")]
    public async Task<ActionResult<ServiceResponse<GetAllStudentsResponse>>> GetAll()
    {
        var response = new ServiceResponse<GetAllStudentsResponse>();

        try
        {
            var students = await _studentCommands.GetAllStudents();
            response.Success = true;
            response.Message = _successGetAllMessage;
            response.Data = new GetAllStudentsResponse { Students = students.Select(student => student.ToDefinition()).ToList() };
            return Ok(response);
        }
        catch ( Exception ex )
        {
            _logger.LogError(ex, "Something went wrong while fetching students");
            response.Success = false;
            response.Message = _errorGetAllMessage;
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }

    [HttpGet("getStudent/{id}")]
    public async Task<ActionResult<ServiceResponse<GetStudentResponse>>> GetStudent(string id)
    {
        var response = new ServiceResponse<GetStudentResponse>();

        try
        {
            var student = await _studentCommands.GetStudentById(Guid.Parse(id));
            response.Success = true;
            response.Message = _successGetStudentMessage;
            response.Data = new GetStudentResponse { Student = student.ToDefinition() };
            return Ok(response);
        }
        catch ( Exception ex )
        {
            _logger.LogError(ex, "Something went wrong while fetching student by id");
            response.Success = false;
            response.Message = _errorGetStudentMessage;
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }

    [HttpPost("createStudent")]
    public async Task<ActionResult<ServiceResponse<CreateStudentResponse>>> CreateStudent(CreateStudentRequest request)
    {
        var response = new ServiceResponse<CreateStudentResponse>();

        try
        {
            var student = await _studentCommands.CreateStudent(request);
            response.Success = true;
            response.Message = _successsCreateStudentMessage;
            response.Data = new CreateStudentResponse { Student = student.ToDefinition() };
            return Ok(response);
        }
        catch ( Exception ex )
        {
            _logger.LogError(ex, "Something went wrong while creating student");
            response.Success = false;
            response.Message = _errorCreateStudentMessage;
            return BadRequest(response);
        }
    }

    [HttpPut("updateStudent")]
    public async Task<ActionResult<ServiceResponse<UpdateStudentResponse>>> UpdateStudent(UpdateStudentRequest request)
    {
        var response = new ServiceResponse<UpdateStudentResponse>();

        try
        {
            var student = await _studentCommands.UpdateStudent(request);
            response.Success = true;
            response.Message = _successUpdateStudentMessage;
            response.Data = new UpdateStudentResponse { Student = student.ToDefinition() };
            return Ok(response);
        }
        catch ( Exception ex )
        {
            _logger.LogError(ex, "Something went wrong updating student");
            response.Success = false;
            response.Message = _errorUpdateStudentMessage;
            return BadRequest(response);
        }
    }

    [HttpDelete("deleteStudent")]
    public async Task<ActionResult<ServiceResponse<DeleteStudentResponse>>> DeleteStudent(DeleteStudentRequest request)
    {
        var response = new ServiceResponse<DeleteStudentResponse>();
        try
        {
            var student = await _studentCommands.DeleteStudent(request);
            response.Success = true;
            response.Message = _successDeleteStudentMessage;
            response.Data = new DeleteStudentResponse { StudenRemoved = student.ToDefinition() };
            return Ok(response);
        }
        catch ( Exception ex )
        {
            _logger.LogError(ex, "Something went wrong remove student");
            response.Success = false;
            response.Message = _errorDeleteStudentMessage;
            return BadRequest(response);
        }
    }
}
