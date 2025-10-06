using Api.Gateway.Models.Catalogos.DTOs.CTEntregables;
using Api.Gateway.Models.Catalogos.DTOs.CTExpedientes;
using Api.Gateway.Proxies.Catalogos.CTExpedientes.Queries;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Catalogos.CTExpedientes.Queries
{
    public interface IQCTExpedienteProxy
    {
        Task<List<CTExpedienteDto>> GetAllExpedientesAsync();
        Task<List<CTExpedienteDto>> GetExpedientesByAsunto(int asunto);
        Task<CTExpedienteDto> GetExpedienteById(int id);
    }

    public class QCTExpedienteProxy : IQCTExpedienteProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QCTExpedienteProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<CTExpedienteDto>> GetAllExpedientesAsync()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/ctexpedientes/getAllExpedientesAsync");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTExpedienteDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        
        public async Task<List<CTExpedienteDto>> GetExpedientesByAsunto(int asunto)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/ctexpedientes/getExpedientesByAsunto/{asunto}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTExpedienteDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<CTExpedienteDto> GetExpedienteById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/ctexpedientes/getExpedienteById/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<CTExpedienteDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
