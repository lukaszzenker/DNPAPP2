using API.Database;
using DomainLibrary;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GradesController : Controller
    {
        private readonly ILogger<GradesController> _logger;
        private readonly IDataService service;

        public GradesController(ILogger<GradesController> logger, IDataService s)
        {
            _logger = logger;
            service = s;
        }

        [HttpGet]
        [Route("{courseCode:String")]
        public async Task<ActionResult<StatisticsOverviewDto>> GetCourseStatisticsAsync([FromRoute] String courseCode)
        {
            StatisticsOverviewDto stats = await service.GetCourseStatistics(courseCode);
            return stats;
        }
    }
}
