using CrudEscuela.Shared.Student.Definition;

namespace CrudEscuela.Shared.Student;

public class GetAllStudentsResponse
{
    public List<StudentDefinition> Students { get; set; } = new List<StudentDefinition>();
}
