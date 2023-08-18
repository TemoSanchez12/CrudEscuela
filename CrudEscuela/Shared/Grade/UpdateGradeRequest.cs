
namespace CrudEscuela.Shared.Grade;

public class UpdateGradeRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid ProfessorId { get; set; }
}
