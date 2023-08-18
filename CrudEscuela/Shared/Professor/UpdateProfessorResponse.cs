
using CrudEscuela.Shared.Professor.Definition;

namespace CrudEscuela.Shared.Professor;

public class UpdateProfessorResponse
{
    public ProfessorDefinition Professor { get; set; } = new ProfessorDefinition();
}
