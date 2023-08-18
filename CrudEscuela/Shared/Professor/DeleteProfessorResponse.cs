using CrudEscuela.Shared.Professor.Definition;

namespace CrudEscuela.Shared.Professor;

public class DeleteProfessorResponse
{
    public ProfessorDefinition ProfessorRemoved { get; set; } = new ProfessorDefinition();
}
