using Microsoft.Extensions.Options;
using SSTHub.Identity.Infrastructure;
using SSTHub.Identity.Services.Interfaces;
using System.Text.Json;
using System.Text;
using SSTHub.Identity.Models.Dtos;

namespace SSTHub.Identity.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly HttpClient _httpClient;
        private readonly string _organizationBaseUrl;

        public OrganizationService(IOptions<AppSettings> settings, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _settings = settings;

            _organizationBaseUrl = $"{_settings.Value.OrganizationUrl}";
        }

        public async Task<int> CreateAsync(OrganizationCreateDto dto)
        {
            var uri = API.Organization.CreateOrganization(_organizationBaseUrl);

            using StringContent jsonContent = new(
                JsonSerializer.Serialize(dto),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(uri, jsonContent);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var organizationId = int.Parse(jsonResponse);
            return organizationId;
        }
    }
}
