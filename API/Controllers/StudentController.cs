using Microsoft.AspNetCore.Mvc;
using DomainLibrary;
using API.Database;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IDataService service;

        public StudentController(ILogger<StudentController> logger, IDataService s)
        {
            _logger = logger;
            service = s;
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateAsync([FromBody] Student student)
        {
            try
            {
                Student added = await service.CreateStudentAsync(student);
                return Created($"/{added.studentId}", added);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllAsync()
        {
            List<Student> list = await service.GetAllStudentsAsync();
            return list;
        }
        [HttpPost]
        [Route("Grade/{studentId:int}")]
        public async Task<ActionResult> AddGradeToStudentAsync([FromBody] GradeInCourse grade,[FromRoute] int studentId)
        {
            try
            {
                await service.AddGradeToStudentAsync( grade, studentId);
                return Created($"/{studentId}", grade);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}
