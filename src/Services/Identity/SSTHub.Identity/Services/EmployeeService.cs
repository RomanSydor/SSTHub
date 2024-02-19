using Microsoft.Extensions.Options;
using SSTHub.Identity.Infrastructure;
using SSTHub.Identity.Models.Dtos;
using SSTHub.Identity.Services.Interfaces;
using System.Text.Json;
using System.Text;

namespace SSTHub.Identity.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _httpClient;
        private readonly string _employeeBaseUrl;

        public EmployeeService(IOptions<AppSettings> settings, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _settings = settings;

            _employeeBaseUrl = $"{_settings.Value.EmployeeUrl}";
        }

        public async Task<int> CreateAsync(EmployeeCreateDto createDto)
        {
            var uri = API.Hub.CreateHub(_employeeBaseUrl);

            using StringContent jsonContent = new(
                JsonSerializer.Serialize(createDto),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(uri, jsonContent);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            try
            {
                var employeeId = int.Parse(jsonResponse);
                return employeeId;
            }
            catch (FormatException)
            {
                throw new FormatException($"Could not parse {jsonResponse}");
            }
            catch (Exception)
            {
                throw new Exception($"{jsonResponse}");
            }
        }
    }
}
