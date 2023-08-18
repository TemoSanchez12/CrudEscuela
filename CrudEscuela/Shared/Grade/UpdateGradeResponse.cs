
using CrudEscuela.Shared.Grade.Definition;

namespace CrudEscuela.Shared.Grade;

public class UpdateGradeResponse
{
    public GradeDefinition Grade { get; set; } = new GradeDefinition();
}
