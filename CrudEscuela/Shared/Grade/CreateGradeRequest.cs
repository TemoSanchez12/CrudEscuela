
namespace CrudEscuela.Shared.Grade;

public class CreateGradeRequest
{
    public string Name { get; set; } = string.Empty;
    public Guid ProfessorId { get; set; }
}
