
namespace CrudEscuela.Shared.StudentGrade;

public class CreateStudentGradeRequest
{
    public Guid StudentId { get; set; }
    public Guid GradeId { get; set; }
    public string Section { get; set; } = string.Empty;
}
