using CrudEscuela.Shared.Utils;

namespace CrudEscuela.Shared.Professor.Definition;

public class ProfessorDefinition
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public GenreDefinition Genre { get; set; }
}
