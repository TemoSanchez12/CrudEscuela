using CrudEscuela.Shared.StudentGrade.Definition;

namespace CrudEscuela.Server.Data.Models;

public class StudentGrade
{
    public Guid Id { get; set; }
    public Student Student { get; set; } = new();
    public Grade Grade { get; set; } = new();
    public string Section { get; set; } = string.Empty;

    public StudentGradeDefinition ToDefinition()
    {
        return new()
        {
            Id = Id,
            Student = Student.ToDefinition(),
            Grade = Grade.ToDefinition(),
            Section = Section
        };
    }

}
