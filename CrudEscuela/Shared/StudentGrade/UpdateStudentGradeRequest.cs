
namespace CrudEscuela.Shared.StudentGrade;

public class UpdateStudentGradeRequest
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; }
    public Guid GradeId { get; set; }
    public string Section { get; set; } = string.Empty;
}
