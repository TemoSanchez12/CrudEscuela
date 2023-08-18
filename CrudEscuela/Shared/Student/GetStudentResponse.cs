
using CrudEscuela.Shared.Student.Definition;

namespace CrudEscuela.Shared.Student;

public class GetStudentResponse
{
    public StudentDefinition Student { get; set; } = new();
}
