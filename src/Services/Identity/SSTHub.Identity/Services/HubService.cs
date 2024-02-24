using Microsoft.Extensions.Options;
using SSTHub.Identity.Infrastructure;
using SSTHub.Identity.Models.Dtos;
using SSTHub.Identity.Services.Interfaces;
using System.Text.Json;
using System.Text;

namespace SSTHub.Identity.Services
{
    public class HubService : IHubService
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _httpClient;
        private readonly string _hubBaseUrl;

        public HubService(IOptions<AppSettings> settings, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _settings = settings;

            _hubBaseUrl = $"{_settings.Value.HubUrl}";
        }

        public async Task<int> CreateAsync(HubCreateDto createDto)
        {
            var uri = API.Hub.CreateHub(_hubBaseUrl);

            using StringContent jsonContent = new(
                JsonSerializer.Serialize(createDto),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(uri, jsonContent);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var hubId = int.Parse(jsonResponse);
            return hubId;
        }
    }
}
