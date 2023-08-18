using CrudEscuela.Server.Data.Models.Utils;
using CrudEscuela.Shared.Professor.Definition;
using CrudEscuela.Shared.Student.Definition;
using CrudEscuela.Shared.Utils;

namespace CrudEscuela.Server.Data.Models;

public class Professor
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public Genre Genre { get; set; }

    public ProfessorDefinition ToDefinition()
    {
        var genre = Genre switch
        {
            Genre.Male => GenreDefinition.Male,
            Genre.Female => GenreDefinition.Female,
            Genre.Other => GenreDefinition.Other,
            _ => throw new NotImplementedException()
        };

        return new ProfessorDefinition { Id = Id, Name = Name, LastName = LastName, Genre = genre };
    }
}
