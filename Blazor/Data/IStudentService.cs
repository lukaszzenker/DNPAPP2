using DomainLibrary;

namespace Blazor.Data
{
    public interface IStudentService
    {
        Task CreateAsync(Student student);

        Task<List<Student>> GetAllStudentsAsync();
        Task AddGradeToStudentAsync(GradeInCourse grade, int studentId);
    }
}
