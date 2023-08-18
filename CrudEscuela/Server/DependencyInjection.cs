using CrudEscuela.Server.Commands;
using CrudEscuela.Server.Commands.Contracts;

namespace CrudEscuela.Server;

public static class DependencyInjection
{
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IStudentCommands, StudentCommands>();
        services.AddScoped<IProfessorCommands, ProfessorCommands>();
        services.AddScoped<IGradeCommands, GradeCommands>();
        services.AddScoped<IStudentGradeCommands, StudentGradeCommands>();
    }
}
