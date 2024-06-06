using DomainLibrary;
using System.Text.Json;
using System.Text;

namespace Blazor.Data
{
    public class StudentHttpClient : IStudentService
    {
        private string uri = "https://localhost:7270";
        private readonly HttpClient client;

        public StudentHttpClient() 
        {
            client = new HttpClient();
        }
        public async Task CreateAsync(Student student)
        {
            string studentAsJson = JsonSerializer.Serialize(student);
            HttpContent content = new StringContent(
                studentAsJson,
                Encoding.UTF8,
                "application/json"
                );


            HttpResponseMessage response = await client.PostAsync(uri + "/Student", content);
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Student");

            string message = await stringAsync;



            List<Student> result = JsonSerializer.Deserialize<List<Student>>(message,
                                                                new JsonSerializerOptions
                                                                {
                                                                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                                                                });
            return result;
        }

        public async Task AddGradeToStudentAsync(GradeInCourse grade, int studentId)
        {
            string gradeAsJson = JsonSerializer.Serialize(grade);
            HttpContent content = new StringContent(
                gradeAsJson,
                Encoding.UTF8,
                "application/json"
                );
            HttpResponseMessage response = await client.PostAsync(uri + $"/Student/Grade/{studentId}", content);
            if (!response.IsSuccessStatusCode)
            {
                string errorLabel = $"Error, {response.StatusCode}, {response.ReasonPhrase}";
                return;
            }
        }
    }
}
