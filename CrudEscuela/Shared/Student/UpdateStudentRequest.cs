

namespace CrudEscuela.Shared.Student;

public class UpdateStudentRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Genre { get; set; }
    public DateTime BirthDate { get; set; }
}
