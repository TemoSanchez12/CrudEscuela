
using CrudEscuela.Shared.Student.Definition;

namespace CrudEscuela.Shared.Student;

public class CreateStudentResponse
{
    public StudentDefinition Student { get; set; } = new();
}
