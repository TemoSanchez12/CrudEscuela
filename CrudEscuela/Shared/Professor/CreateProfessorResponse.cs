
using CrudEscuela.Shared.Professor.Definition;

namespace CrudEscuela.Shared.Professor;

public class CreateProfessorResponse
{
    public ProfessorDefinition Professor { get; set; } = new ProfessorDefinition();
}
