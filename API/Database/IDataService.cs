using DomainLibrary;

namespace API.Database
{
    public interface IDataService
    {
        Task<Student> CreateStudentAsync(Student student);
        Task<List<Student>> GetAllStudentsAsync();
        Task AddGradeToStudentAsync(GradeInCourse grade, int studentId);
        Task<StatisticsOverviewDto> GetCourseStatistics(String courseCode);

    }
}
