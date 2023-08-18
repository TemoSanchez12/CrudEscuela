using CrudEscuela.Server.Commands.Contracts;
using CrudEscuela.Server.Data;
using CrudEscuela.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using CrudEscuela.Shared.Grade;

namespace CrudEscuela.Server.Commands;

public class GradeCommands : IGradeCommands
{
    private readonly IDbContextFactory<GlobalDbContext> _dbContextFactory;
    private readonly ILogger<ProfessorCommands> _logger;

    public GradeCommands(IDbContextFactory<GlobalDbContext> dbContextFactory, ILogger<ProfessorCommands> logger)
    {
        _dbContextFactory = dbContextFactory;
        _logger = logger;
    }

    public async Task<List<Grade>> GetAllGrades()
    {
        _logger.LogInformation("Fetching all grades at {Date}", DateTime.Now);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();
        var grades = await dbContext.Grades.Include(g => g.Professor).ToListAsync();
        return grades;
    }

    public async Task<Grade> GetGradeById(Guid id)
    {
        _logger.LogInformation("Fetching student with id {Id}", id);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var grade = await dbContext.Grades.Include(g => g.Professor).FirstOrDefaultAsync(s => s.Id == id);

        if ( grade == null )
            throw new Exception($"Grade with id {id} not found");

        return grade;
    }

    public async Task<Grade> CreateGrade(CreateGradeRequest request)
    {
        _logger.LogInformation("Creating grade with name {GradeName} and professor id {ProfessorId}", request.Name, request.ProfessorId);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var professor = await dbContext.Professors.FirstOrDefaultAsync(p => p.Id == request.ProfessorId);

        if ( professor == null )
            throw new Exception("Professor not found");

        var grade = new Grade
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Professor = professor
        };

        await dbContext.Grades.AddAsync(grade);
        await dbContext.SaveChangesAsync();

        return grade;
    }


    public async Task<Grade> UpdateGrade(UpdateGradeRequest request)
    {
        _logger.LogInformation("Update grade with id {Id}", request.Id);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var grade = await dbContext.Grades.FirstOrDefaultAsync(s => s.Id == request.Id);
        var professor = await dbContext.Professors.FirstOrDefaultAsync(p => p.Id == request.ProfessorId);

        if ( professor == null )
            throw new Exception("Professor not found");

        if ( grade == null )
            throw new Exception("Grade not found");

        grade.Name = request.Name;
        grade.Professor = professor;


        await dbContext.SaveChangesAsync();

        return grade;
    }

    public async Task<Grade> DeleteGrade(DeleteGradeRequest request)
    {
        _logger.LogInformation("Removing grade with id {Id}", request.GradeId);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var grade = await dbContext.Grades.FirstOrDefaultAsync(s => s.Id == request.GradeId);

        if ( grade == null )
            throw new Exception("No grade found");

        dbContext.Remove(grade);
        await dbContext.SaveChangesAsync();

        return grade;
    }
}
