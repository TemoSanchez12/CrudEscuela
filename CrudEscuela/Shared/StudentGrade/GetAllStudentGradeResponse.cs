
using CrudEscuela.Shared.StudentGrade.Definition;

namespace CrudEscuela.Shared.StudentGrade;

public class GetAllStudentGradeResponse
{
    public List<StudentGradeDefinition> StudentGrades { get; set; } = new List<StudentGradeDefinition>();
}
