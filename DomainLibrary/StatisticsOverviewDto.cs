using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary
{
    public class StatisticsOverviewDto
    {
        public String CourseCode { get; set; }
        public int TotalNumOfPassedStudents { get; set; }
        public int TotalNumOfStudents { get; set; }
        public double AvgGradeOverall { get; set; }
        public double AvgGradeOfPassed { get; set; }
        public double MedianGrade { get; set; }

    }
}
