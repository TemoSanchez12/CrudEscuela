
using CrudEscuela.Shared.Grade.Definition;

namespace CrudEscuela.Shared.Grade;

public class GetAllGradesResponse
{
    public List<GradeDefinition> Grades { get; set; } = new List<GradeDefinition>();
}
