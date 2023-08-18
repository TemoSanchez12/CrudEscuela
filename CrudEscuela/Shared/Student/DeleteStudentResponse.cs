
using CrudEscuela.Shared.Student.Definition;

namespace CrudEscuela.Shared.Student;

public class DeleteStudentResponse
{
    public StudentDefinition StudenRemoved { get; set; } = new StudentDefinition();
}
