using CrudEscuela.Server.Data.Models;
using CrudEscuela.Shared.Professor;

namespace CrudEscuela.Server.Commands.Contracts;

public interface IProfessorCommands
{
    Task<List<Professor>> GetAllProfessors();
    Task<Professor> GetProfessorById(Guid id);
    Task<Professor> CreateProfessor(CreateProfessorRequest request);
    Task<Professor> UpdateProfessor(UpdateProfessorRequest request);
    Task<Professor> DeleteProfessor(DeleteProfessorRequest request);
}
