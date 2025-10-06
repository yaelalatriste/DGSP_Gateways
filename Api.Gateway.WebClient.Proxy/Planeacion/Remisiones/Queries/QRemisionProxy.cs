using Api.Gateway.Models.Planeacion.Queries.Remisiones;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Planeacion.Remisiones.Queries
{
    public interface IQRemisionProxy
    {
        Task<List<RemisionDto>> GetAllRemisiones();
        Task<RemisionDto> GetRemisionById(int id);
    }
    public class QRemisionProxy : IQRemisionProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QRemisionProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<RemisionDto>> GetAllRemisiones()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}planeacion/remisiones/getAllRemisiones");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<RemisionDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<RemisionDto> GetRemisionById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}planeacion/remisiones/getRemisionById/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<RemisionDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
