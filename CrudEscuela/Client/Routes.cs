namespace CrudEscuela.Client;

public static class Routes
{
    public static string Home = "/";
    public static class Student
    {
        public const string StudentList = "/estudiantes";
        public const string CreateStudent = "/estudiante/crear";
        public const string UpdateStudent = "/estudiantes/actualizar/{Id}";
    }

    public static class Professor
    {
        public const string ProfessorList = "/profesores";
        public const string CreateProfessor = "/profesores/crear";
        public const string UpdateProfessor = "/profesores/actualizar/{Id}";
    }

    public static class Grade
    {
        public const string GradesList = "/grados";
        public const string CreateGrade = "/grados/crear";
        public const string UpdateGrade = "/grados/actualizar/{Id}";
    }

    public static class StudentGrade
    {
        public const string StudentGradeList = "/estudiante-grados";
        public const string CreateStudentGrade = "/estudiante-grados/crear";
        public const string UpdateStudentGrade = "/estudiante-grados/actualizar/{Id}";
    }

    public static string InjectId(string route, string id)
    {
        return route.Replace("{Id}", id);
    }
}
