using CrudEscuela.Server.Commands.Contracts;
using CrudEscuela.Server.Data;
using CrudEscuela.Server.Data.Models.Utils;
using CrudEscuela.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using CrudEscuela.Shared.Professor;

namespace CrudEscuela.Server.Commands;

public class ProfessorCommands : IProfessorCommands
{
    private readonly IDbContextFactory<GlobalDbContext> _dbContextFactory;
    private readonly ILogger<ProfessorCommands> _logger;

    public ProfessorCommands(IDbContextFactory<GlobalDbContext> dbContextFactory, ILogger<ProfessorCommands> logger)
    {
        _dbContextFactory = dbContextFactory;
        _logger = logger;
    }

    public async Task<List<Professor>> GetAllProfessors()
    {
        _logger.LogInformation("Fetching all professors at {Date}", DateTime.Now);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();
        var professors = await dbContext.Professors.ToListAsync();
        return professors;
    }

    public async Task<Professor> GetProfessorById(Guid id)
    {
        _logger.LogInformation("Fetching proffessor with id {Id}", id);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var professor = await dbContext.Professors.FirstOrDefaultAsync(s => s.Id == id);

        if ( professor == null )
            throw new Exception($"Professor with id {id} not found");

        return professor;
    }

    public async Task<Professor> CreateProfessor(CreateProfessorRequest request)
    {
        _logger.LogInformation("Creating professor with name", request.Name);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var professor = new Professor
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            LastName = request.LastName,
            Genre = request.Genre switch
            {
                "Male" => Genre.Male,
                "Female" => Genre.Female,
                "Other" => Genre.Other,
                _ => throw new NotImplementedException()
            }
        };

        await dbContext.Professors.AddAsync(professor);
        await dbContext.SaveChangesAsync();

        return professor;
    }


    public async Task<Professor> UpdateProfessor(UpdateProfessorRequest request)
    {
        _logger.LogInformation("Update professor with id {Id}", request.Id);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var professor = await dbContext.Professors.FirstOrDefaultAsync(s => s.Id == request.Id);

        if ( professor == null )
            throw new Exception("User not found");

        professor.Name = request.Name;
        professor.LastName = request.LastName;
        professor.Genre = request.Genre switch
        {
            "Male" => Genre.Male,
            "Female" => Genre.Female,
            "Other" => Genre.Other,
            _ => throw new NotImplementedException()
        };

        await dbContext.SaveChangesAsync();

        return professor;
    }

    public async Task<Professor> DeleteProfessor(DeleteProfessorRequest request)
    {
        _logger.LogInformation("Removing student with id {Id}", request.ProfesssorId);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var professor = await dbContext.Professors.FirstOrDefaultAsync(s => s.Id == request.ProfesssorId);

        if ( professor == null )
            throw new Exception("No professor found");

        dbContext.Remove(professor);
        await dbContext.SaveChangesAsync();

        return professor;
    }
}
