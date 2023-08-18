
namespace CrudEscuela.Shared.Student;

public class CreateStudentRequest
{
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
}
