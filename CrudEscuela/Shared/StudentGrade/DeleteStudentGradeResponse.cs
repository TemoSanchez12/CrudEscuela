
using CrudEscuela.Shared.StudentGrade.Definition;

namespace CrudEscuela.Shared.StudentGrade;

public class DeleteStudentGradeResponse
{
    public StudentGradeDefinition RemovedStudentGrade { get; set; } = new StudentGradeDefinition();
}
