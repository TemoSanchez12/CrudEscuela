using CrudEscuela.Server.Data.Models;
using CrudEscuela.Shared.Grade;

namespace CrudEscuela.Server.Commands.Contracts;

public interface IGradeCommands
{
    Task<List<Grade>> GetAllGrades();
    Task<Grade> GetGradeById(Guid id);
    Task<Grade> CreateGrade(CreateGradeRequest request);
    Task<Grade> UpdateGrade(UpdateGradeRequest request);
    Task<Grade> DeleteGrade(DeleteGradeRequest request);

}
