using Api.Gateway.Models.Catalogos.DTOs.CTAsuntos;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Catalogos.CTAsuntos.Queries
{
    public interface IQCTAsuntoProxy
    {
        Task<List<CTAsuntoDto>> GetAllAsuntosAsync();
        Task<List<CTAsuntoDto>> GetAsuntosByArea(int area);

        Task<CTAsuntoDto> GetAsuntoById(int id);
    }

    public class QCTAsuntoProxy : IQCTAsuntoProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QCTAsuntoProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<CTAsuntoDto>> GetAllAsuntosAsync()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/ctasuntos/getAllAsuntosAsync");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTAsuntoDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        
        public async Task<List<CTAsuntoDto>> GetAsuntosByArea(int area)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/ctasuntos/getAsuntosByArea/{area}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTAsuntoDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<CTAsuntoDto> GetAsuntoById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/ctasuntos/getAsuntoById/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<CTAsuntoDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
