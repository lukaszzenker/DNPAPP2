using DomainLibrary;
using System.Text.Json;
using System;

namespace Blazor.Data
{
    public class GradeHttpClient : IGradeService
    {
        private string uri = "https://localhost:7270";
        private readonly HttpClient client;

        public GradeHttpClient()
        {
            client = new HttpClient();
        }
        public async Task<StatisticsOverviewDto> GetStatisticsAsync(string courseCode)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Grade");

            string message = await stringAsync;



            StatisticsOverviewDto stats = JsonSerializer.Deserialize<StatisticsOverviewDto>(message,
                                                                new JsonSerializerOptions
                                                                {
                                                                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                                                                });
            return stats;
        }
    }
}
