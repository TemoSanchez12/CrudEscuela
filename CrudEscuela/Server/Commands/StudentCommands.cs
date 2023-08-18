using CrudEscuela.Server.Commands.Contracts;
using CrudEscuela.Server.Data;
using CrudEscuela.Server.Data.Models;
using CrudEscuela.Server.Data.Models.Utils;
using CrudEscuela.Shared.Student;
using Microsoft.EntityFrameworkCore;

namespace CrudEscuela.Server.Commands;

public class StudentCommands : IStudentCommands
{
    private readonly IDbContextFactory<GlobalDbContext> _dbContextFactory;
    private readonly ILogger<StudentCommands> _logger;

    public StudentCommands(IDbContextFactory<GlobalDbContext> dbContextFactory, ILogger<StudentCommands> logger)
    {
        _dbContextFactory = dbContextFactory;
        _logger = logger;
    }

    public async Task<List<Student>> GetAllStudents()
    {
        _logger.LogInformation("Fetching all students at {Date}", DateTime.Now);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();
        var students = await dbContext.Students.ToListAsync();
        return students;
    }

    public async Task<Student> GetStudentById(Guid id)
    {
        _logger.LogInformation("Fetching student with id {Id}", id);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var student = await dbContext.Students.FirstOrDefaultAsync(s => s.Id == id);

        if ( student == null )
            throw new Exception($"Student with id {id} not found");

        return student;
    }

    public async Task<Student> CreateStudent(CreateStudentRequest request)
    {
        _logger.LogInformation("Creating student with name", request.Name);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var student = new Student
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            LastName = request.LastName,
            BirthDate = request.BirthDate,
            Genre = request.Genre switch
            {
                "Male" => Genre.Male,
                "Female" => Genre.Female,
                "Other" => Genre.Other,
                _ => throw new NotImplementedException()
            }
        };

        await dbContext.Students.AddAsync(student);
        await dbContext.SaveChangesAsync();

        return student;
    }


    public async Task<Student> UpdateStudent(UpdateStudentRequest request)
    {
        _logger.LogInformation("Update student with id {Id}", request.Id);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var student = await dbContext.Students.FirstOrDefaultAsync(s => s.Id == request.Id);

        if ( student == null )
            throw new Exception("User not found");

        student.Name = request.Name;
        student.LastName = request.LastName;
        student.BirthDate = request.BirthDate;
        student.Genre = request.Genre switch
        {
            "Male" => Genre.Male,
            "Female" => Genre.Female,
            "Other" => Genre.Other,
            _ => throw new NotImplementedException()
        };

        await dbContext.SaveChangesAsync();

        return student;
    }

    public async Task<Student> DeleteStudent(DeleteStudentRequest request)
    {
        _logger.LogInformation("Removing student with id {Id}", request.StudentId);
        var dbContext = await _dbContextFactory.CreateDbContextAsync();

        var student = await dbContext.Students.FirstOrDefaultAsync(s => s.Id == request.StudentId);

        if ( student == null )
            throw new Exception("No student found");

        dbContext.Remove(student);
        await dbContext.SaveChangesAsync();

        return student;
    }
}
