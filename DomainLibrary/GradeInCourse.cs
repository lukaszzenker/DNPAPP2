using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary
{
    public class GradeInCourse
    {
        [Key, MaxLength(4)]
        public String CourseCode { get; set; }

        [Required]
        public int Grade { get; set; }
    }
}
