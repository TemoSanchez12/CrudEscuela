
using CrudEscuela.Shared.Professor.Definition;

namespace CrudEscuela.Shared.Professor;

public class GetProfessorResponse
{
    public ProfessorDefinition Professor { get; set; } = new ProfessorDefinition();
}
