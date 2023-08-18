using CrudEscuela.Shared.Utils;

namespace CrudEscuela.Shared.Student.Definition;

public class StudentDefinition
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public GenreDefinition Genre { get; set; }
    public DateTime BirthDate { get; set; }
}
