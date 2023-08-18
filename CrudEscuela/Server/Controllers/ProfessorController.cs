using CrudEscuela.Server.Commands.Contracts;
using CrudEscuela.Shared.Student;
using CrudEscuela.Shared;
using Microsoft.AspNetCore.Mvc;
using CrudEscuela.Shared.Professor;

namespace CrudEscuela.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfessorController : ControllerBase
{
    private readonly static string _successGetAllMessage = "Se han devuelto todos los profesores";
    private readonly static string _successGetProfessorMessage = "Se ha devuelto el profesores";
    private readonly static string _errorGetAllMessage = "Ocurrio un error al devolver todos los profesores";
    private readonly static string _errorGetProfessorMessage = "Ocurrio un error al devolver al profesores";
    private readonly static string _successsCreateProfessorMessage = "Se ha creado al profesor correctamente";
    private readonly static string _errorCreateProfessorMessage = "Algo ha salido mal al crear profesor";
    private readonly static string _successUpdateProfessorMessage = "El profesor se ha actualizado corectamente";
    private readonly static string _errorUpdateProfessorMessage = "Algo ha salido mal al actualizar al profesor";
    private readonly static string _successDeleteProfessorMessage = "El profesor se ha removido correctamente";
    private readonly static string _errorDeleteProfessorMessage = "Algo ha salido mal al remover profesor";

    private readonly IProfessorCommands _professorCommands;
    private readonly ILogger<ProfessorController> _logger;

    public ProfessorController(IProfessorCommands professorCommands, ILogger<ProfessorController> logger)
    {
        _professorCommands = professorCommands;
        _logger = logger;
    }


    [HttpGet("getAll")]
    public async Task<ActionResult<ServiceResponse<GetAllProfessorsResponse>>> GetAll()
    {
        var response = new ServiceResponse<GetAllProfessorsResponse>();

        try
        {
            var professors = await _professorCommands.GetAllProfessors();
            response.Success = true;
            response.Message = _successGetAllMessage;
            response.Data = new GetAllProfessorsResponse { Professors = professors.Select(professor => professor.ToDefinition()).ToList() };
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Something went wrong while fetching professors");
            response.Success = false;
            response.Message = _errorGetAllMessage;
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }

    [HttpGet("getProfessor/{id}")]
    public async Task<ActionResult<ServiceResponse<GetProfessorResponse>>> GetProfessot(string id)
    {
        var response = new ServiceResponse<GetProfessorResponse>();

        try
        {
            var professor = await _professorCommands.GetProfessorById(Guid.Parse(id));
            response.Success = true;
            response.Message = _successGetProfessorMessage;
            response.Data = new GetProfessorResponse { Professor = professor.ToDefinition() };
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Something went wrong while fetching professor by id");
            response.Success = false;
            response.Message = _errorGetProfessorMessage;
            return StatusCode(StatusCodes.Status500InternalServerError, response);
        }
    }

    [HttpPost("createProfessor")]
    public async Task<ActionResult<ServiceResponse<CreateProfessorResponse>>> CreateProfessot(CreateProfessorRequest request)
    {
        var response = new ServiceResponse<CreateProfessorResponse>();

        try
        {
            var professor = await _professorCommands.CreateProfessor(request);
            response.Success = true;
            response.Message = _successsCreateProfessorMessage;
            response.Data = new CreateProfessorResponse { Professor = professor.ToDefinition() };
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Something went wrong while creating professor");
            response.Success = false;
            response.Message = _errorCreateProfessorMessage;
            return BadRequest(response);
        }
    }

    [HttpPut("updateProfessor")]
    public async Task<ActionResult<ServiceResponse<UpdateProfessorResponse>>> UpdateProfessot(UpdateProfessorRequest request)
    {
        var response = new ServiceResponse<UpdateProfessorResponse>();

        try
        {
            var professor = await _professorCommands.UpdateProfessor(request);
            response.Success = true;
            response.Message = _successUpdateProfessorMessage;
            response.Data = new UpdateProfessorResponse { Professor = professor.ToDefinition() };
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Something went wrong updating professor");
            response.Success = false;
            response.Message = _errorUpdateProfessorMessage;
            return BadRequest(response);
        }
    }

    [HttpDelete("deleteProfessor")]
    public async Task<ActionResult<ServiceResponse<DeleteProfessorResponse>>> DeleteProfessot(DeleteProfessorRequest request)
    {
        var response = new ServiceResponse<DeleteProfessorResponse>();
        try
        {
            var professor = await _professorCommands.DeleteProfessor(request);
            response.Success = true;
            response.Message = _successDeleteProfessorMessage;
            response.Data = new DeleteProfessorResponse { ProfessorRemoved = professor.ToDefinition() };
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Something went wrong remove professor");
            response.Success = false;
            response.Message = _errorDeleteProfessorMessage;
            return BadRequest(response);
        }
    }

}
