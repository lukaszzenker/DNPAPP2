using DomainLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Database
{
    public class DataAccess : IDataService
    {
        private StudentContext ctx;
        public DataAccess(StudentContext context)
        {
            this.ctx = context;
            ctx.Database.Migrate();
        }

        public async Task AddGradeToStudentAsync(GradeInCourse grade, int studentId)
        {
            EntityEntry<GradeInCourse> addedGrade = await ctx.Grades.AddAsync(grade);
            Student student = ctx.Students.Find(studentId);
            if (student != null)
            {
                if (student.Grades == null)
                {
                    student.Grades = new();
                }

                student.Grades.Add(addedGrade.Entity);
                ctx.Students.Update(student);

                await ctx.SaveChangesAsync();
            }
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            EntityEntry<Student> addedStudent = await ctx.Students.AddAsync(student);

            await ctx.SaveChangesAsync();

            return addedStudent.Entity;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            List<Student> list = await ctx.Students.ToListAsync();
            return list;
        }

        public async Task<StatisticsOverviewDto> GetCourseStatistics(string courseCode)
        {
            StatisticsOverviewDto stats = new StatisticsOverviewDto();
            stats.CourseCode = courseCode;
            stats.TotalNumOfStudents = ctx.Students.Count();
            List<Student> allStudents = ctx.Students.Include(s => s.Grades).ToList();
            int numPassedStudents = 0;
            int sumOfPassingGrades = 0;
            int sumOfAllGrades = 0;
            int median = 0;
            List<int> gradesForMedian= new List<int>();
            foreach (Student student in allStudents) 
            {
                if(!(student.Grades == null))
                {
                    foreach(GradeInCourse gradeInCouse in student.Grades) 
                    {
                        if(gradeInCouse.CourseCode == courseCode && gradeInCouse.Grade>0) 
                        {
                            numPassedStudents++;
                            sumOfPassingGrades = sumOfPassingGrades + gradeInCouse.Grade;
                            sumOfAllGrades = sumOfAllGrades + gradeInCouse.Grade;
                            gradesForMedian.Add(gradeInCouse.Grade);
                        }
                        else if(gradeInCouse.CourseCode == courseCode)
                        {
                            sumOfAllGrades = sumOfAllGrades + gradeInCouse.Grade;
                            gradesForMedian.Add(gradeInCouse.Grade);
                        }
                    }
                }
            }
            int listLenght = gradesForMedian.Count;
            gradesForMedian.Sort();
            //If odd
            if (listLenght% 2 == 1)
            {
                int index = (int)listLenght / 2;
                median = gradesForMedian[index];
            }
            else
            {
                int index = listLenght / 2;
                median = gradesForMedian[index-1] + gradesForMedian[index];
            }
         
            stats.TotalNumOfPassedStudents = numPassedStudents;
            stats.AvgGradeOfPassed = sumOfPassingGrades / numPassedStudents;
            stats.AvgGradeOverall = sumOfAllGrades / numPassedStudents;
            stats.MedianGrade = median;

            return stats;
        }
    }
}
