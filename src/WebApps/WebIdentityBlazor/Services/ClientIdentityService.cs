using System.Text.Json;
using System.Text;
using WebIdentityBlazor.Models;
using WebIdentityBlazor.Services.Interfaces;

namespace WebIdentityBlazor.Services
{
    public class ClientIdentityService : IClientIdentityService
    {
        private readonly HttpClient _httpClient;
        public ClientIdentityService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }
        public async Task OrganizationRegisterAsync(OrganizationRegisterViewModel model)
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json"
            );

            var uri = _httpClient.BaseAddress + "Auth/RegisterOrganization";

            await _httpClient.PostAsync(uri, jsonContent);
        }
    }
}
