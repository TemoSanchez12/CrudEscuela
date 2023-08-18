using CrudEscuela.Shared.Grade.Definition;

namespace CrudEscuela.Server.Data.Models;

public class Grade
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Professor Professor { get; set; } = new Professor();

    public GradeDefinition ToDefinition()
    {
        return new GradeDefinition { Id = Id, Name = Name, Professor = Professor.ToDefinition() };
    }
}
