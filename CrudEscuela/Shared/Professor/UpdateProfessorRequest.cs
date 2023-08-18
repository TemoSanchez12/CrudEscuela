
namespace CrudEscuela.Shared.Professor;

public class UpdateProfessorRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
}
