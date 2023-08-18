using CrudEscuela.Server.Data.Models;
using CrudEscuela.Shared.Student;

namespace CrudEscuela.Server.Commands.Contracts;

public interface IStudentCommands
{
    Task<List<Student>> GetAllStudents();
    Task<Student> GetStudentById(Guid id);
    Task<Student> CreateStudent(CreateStudentRequest request);
    Task<Student> UpdateStudent(UpdateStudentRequest request);
    Task<Student> DeleteStudent(DeleteStudentRequest request);
}
