using CrudEscuela.Server.Data.Models.Utils;
using CrudEscuela.Shared.Utils;
using CrudEscuela.Shared.Student.Definition;

namespace CrudEscuela.Server.Data.Models;

public class Student
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Genre Genre { get; set; }
    public DateTime BirthDate { get; set; }

    public StudentDefinition ToDefinition()
    {
        var genre = Genre switch
        {
            Genre.Male => GenreDefinition.Male,
            Genre.Female => GenreDefinition.Female,
            Genre.Other => GenreDefinition.Other,
            _ => throw new NotImplementedException()
        };

        return new StudentDefinition { Id = Id, Name = Name, LastName = LastName, Genre = genre, BirthDate = BirthDate };
    }
}
