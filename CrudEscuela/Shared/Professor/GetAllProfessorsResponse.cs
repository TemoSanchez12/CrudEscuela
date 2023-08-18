
using CrudEscuela.Shared.Professor.Definition;

namespace CrudEscuela.Shared.Professor;

public class GetAllProfessorsResponse
{
    public List<ProfessorDefinition> Professors { get; set; } = new List<ProfessorDefinition>();
}
