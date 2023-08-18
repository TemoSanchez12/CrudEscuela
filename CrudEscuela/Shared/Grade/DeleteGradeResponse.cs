
using CrudEscuela.Shared.Grade.Definition;

namespace CrudEscuela.Shared.Grade;

public class DeleteGradeResponse
{
    public GradeDefinition Grade { get; set; } = new GradeDefinition();
}
