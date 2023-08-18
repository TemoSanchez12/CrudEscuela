

using CrudEscuela.Shared.StudentGrade.Definition;

namespace CrudEscuela.Shared.StudentGrade;

public class GetStudentGradeResponse
{
    public StudentGradeDefinition StudentGrade { get; set; } = new StudentGradeDefinition();
}
