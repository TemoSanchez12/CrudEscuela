using CrudEscuela.Server.Commands.Contracts;
using Microsoft.EntityFrameworkCore;
using CrudEscuela.Server.Data;
using CrudEscuela.Server.Data.Models;
using CrudEscuela.Shared.StudentGrade;

namespace CrudEscuela.Server.Commands;

public class StudentGradeCommands : IStudentGradeCommands
{
    private readonly IDbContextFactory<GlobalDbContext> _dbContextFactory;
    private readonly ILogger<StudentGradeCommands> _logger;

    public StudentGradeCommands(IDbContextFactory<GlobalDbContext> dbContextFactory, ILogger<StudentGradeCommands> logger)
    {
        _dbContextFactory = dbContextFactory;
        _logger = logger;
    }

    public async Task<List<StudentGrade>> GetAllStudentGrades()
    {
        _logger.LogInformation("Fetching all students grades at {Date}", DateTime.Now);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();
        var studentGrades = await dbContext.StudentGrades
                .Include(s => s.Student)
                .Include(s => s.Grade).ToListAsync();
        return studentGrades;
    }

    public async Task<StudentGrade> GetStudentGradeById(Guid id)
    {
        _logger.LogInformation("Fetching student grade with id {Id}", id);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var studentGrade = await dbContext.StudentGrades
                .Include(s => s.Student)
                .Include(s => s.Grade)
                .FirstOrDefaultAsync(s => s.Id == id);

        if ( studentGrade == null )
            throw new Exception($"Student grade with id {id} not found");

        return studentGrade;
    }

    public async Task<StudentGrade> CreateStudentGrade(CreateStudentGradeRequest request)
    {
        _logger.LogInformation("Creating student grade for student id", request.StudentId);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var student = await dbContext.Students.FirstOrDefaultAsync(s => s.Id == request.StudentId);
        var grade = await dbContext.Grades.FirstOrDefaultAsync(g => g.Id == request.GradeId);

        if ( student == null )
            throw new Exception($"Student with id {request.StudentId} not found");

        if ( grade == null )
            throw new Exception($"Grade with id {request.GradeId} not found");

        var studentGrade = new StudentGrade
        {
            Id = Guid.NewGuid(),
            Student = student,
            Grade = grade,
            Section = request.Section
        };

        await dbContext.StudentGrades.AddAsync(studentGrade);
        await dbContext.SaveChangesAsync();

        return studentGrade;
    }


    public async Task<StudentGrade> UpdateStudentGrade(UpdateStudentGradeRequest request)
    {
        _logger.LogInformation("Update student grade with id {Id}", request.Id);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var studentGrade = await dbContext.StudentGrades.FirstOrDefaultAsync(s => s.Id == request.Id);
        var student = await dbContext.Students.FirstOrDefaultAsync(s => s.Id == request.StudentId);
        var grade = await dbContext.Grades.FirstOrDefaultAsync(g => g.Id == request.GradeId);

        if ( studentGrade == null )
            throw new Exception("Student grade not found");

        if ( student == null )
            throw new Exception($"Student with id {request.StudentId} not found");

        if ( grade == null )
            throw new Exception($"Grade with id {request.GradeId} not found");

        studentGrade.Section = request.Section;
        studentGrade.Student = student;
        studentGrade.Grade = grade;

        await dbContext.SaveChangesAsync();

        return studentGrade;
    }

    public async Task<StudentGrade> DeleteStudentGrade(DeleteStudentGradeRequest request)
    {
        _logger.LogInformation("Removing student grade with id {Id}", request.StudentGradeId);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var studentGrade = await dbContext.StudentGrades.FirstOrDefaultAsync(s => s.Id == request.StudentGradeId);

        if ( studentGrade == null )
            throw new Exception("No student grade found");

        dbContext.Remove(studentGrade);
        await dbContext.SaveChangesAsync();

        return studentGrade;
    }
}
