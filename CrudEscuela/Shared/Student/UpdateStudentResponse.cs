
using CrudEscuela.Shared.Student.Definition;

namespace CrudEscuela.Shared.Student;

public class UpdateStudentResponse
{
    public StudentDefinition Student { get; set; } = new();
}
