using Api.Gateway.Models.Catalogos.DTOs.CTAreas;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Catalogos.CTAreas.Queries
{
    public interface IQCTAreaProxy
    {
        Task<List<CTAreaDto>> GetAllAreasAsync();
        Task<CTAreaDto> GetAreaByIdAsync(int id);
    }

    public class QCTAreaProxy : IQCTAreaProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QCTAreaProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<CTAreaDto>> GetAllAreasAsync()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/areas");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTAreaDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<CTAreaDto> GetAreaByIdAsync(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/areas/getAreaById/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<CTAreaDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
