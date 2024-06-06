using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary
{
    public class Student
    {
        [Key]
        public int studentId { get; set; }

        [Required, MaxLength(25)]
        public String Name { get; set; }
        [Required]
        public String Programme { get; set; }

        public List<GradeInCourse> Grades { get; set; }
    }
}
