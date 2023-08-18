
using CrudEscuela.Shared.Professor.Definition;

namespace CrudEscuela.Shared.Grade.Definition;

public class GradeDefinition
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ProfessorDefinition Professor { get; set; } = new ProfessorDefinition();
}
