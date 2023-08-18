
using CrudEscuela.Shared.Grade.Definition;
using CrudEscuela.Shared.Student.Definition;

namespace CrudEscuela.Shared.StudentGrade.Definition;

public class StudentGradeDefinition
{
    public Guid Id { get; set; }
    public StudentDefinition Student { get; set; } = new StudentDefinition();
    public GradeDefinition Grade { get; set; } = new GradeDefinition();
    public string Section { get; set; } = string.Empty;
}
