using CrudEscuela.Shared.StudentGrade.Definition;

namespace CrudEscuela.Shared.StudentGrade;

public class CreateStudentGradeResponse
{
    public StudentGradeDefinition StudentGrade { get; set; } = new StudentGradeDefinition();
}
