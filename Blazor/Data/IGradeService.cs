using DomainLibrary;

namespace Blazor.Data
{
    public interface IGradeService
    {
        Task<StatisticsOverviewDto> GetStatisticsAsync(String courseCode);
    }
}
