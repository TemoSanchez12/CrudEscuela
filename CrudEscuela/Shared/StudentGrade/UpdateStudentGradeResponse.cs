
using CrudEscuela.Shared.StudentGrade.Definition;

namespace CrudEscuela.Shared.StudentGrade;

public class UpdateStudentGradeResponse
{
    public StudentGradeDefinition StudentGrade { get; set; } = new StudentGradeDefinition();
}
