
using CrudEscuela.Shared.Grade.Definition;

namespace CrudEscuela.Shared.Grade;

public class CreateGradeResponse
{
    public GradeDefinition Grade { get; set; } = new GradeDefinition();
}
