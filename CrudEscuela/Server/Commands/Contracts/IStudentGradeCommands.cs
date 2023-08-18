using CrudEscuela.Server.Data.Models;
using CrudEscuela.Shared.StudentGrade;

namespace CrudEscuela.Server.Commands.Contracts;

public interface IStudentGradeCommands
{
  Task<List<StudentGrade>> GetAllStudentGrades();
  Task<StudentGrade> GetStudentGradeById(Guid id);
  Task<StudentGrade> CreateStudentGrade(CreateStudentGradeRequest request);
  Task<StudentGrade> UpdateStudentGrade(UpdateStudentGradeRequest request);
  Task<StudentGrade> DeleteStudentGrade(DeleteStudentGradeRequest request);
}
