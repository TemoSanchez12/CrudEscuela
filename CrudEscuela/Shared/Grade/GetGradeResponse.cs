
using CrudEscuela.Shared.Grade.Definition;

namespace CrudEscuela.Shared.Grade;

public class GetGradeResponse
{
    public GradeDefinition Grade { get; set; } = new GradeDefinition();
}
