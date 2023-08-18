using CrudEscuela.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudEscuela.Server.Data;

public class GlobalDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Professor> Professors { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<StudentGrade> StudentGrades { get; set; }

    public GlobalDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(builder =>
        {
            builder.HasKey(student => student.Id);
            builder.Property(student => student.Name);
            builder.Property(student => student.LastName);
            builder.Property(student => student.Genre);
            builder.Property(student => student.BirthDate);
        });

        modelBuilder.Entity<Professor>(builder =>
        {
            builder.HasKey(professor => professor.Id);
            builder.Property(professor => professor.Name);
            builder.Property(professor => professor.LastName);
            builder.Property(professor => professor.Genre);
        });

        modelBuilder.Entity<Grade>(builder =>
        {
            builder.HasKey(grade => grade.Id);
            builder.Property(grade => grade.Name);
            builder.HasOne(grade => grade.Professor);
        });

        modelBuilder.Entity<StudentGrade>(builder =>
        {
            builder.HasKey(studentGraade => studentGraade.Id);
            builder.HasOne(studentGrade => studentGrade.Student);
            builder.HasOne(studentGrade => studentGrade.Grade);
            builder.Property(studentGrade => studentGrade.Section);
        });
    }
}
