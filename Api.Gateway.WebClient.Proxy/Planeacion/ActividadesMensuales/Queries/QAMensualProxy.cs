using Api.Gateway.Models.Planeacion.Queries.ActividadesMensuales;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Planeacion.ActividadesMensuales.Queries
{
    public interface IQAMensualProxy
    {
        Task<List<ActividadMensualDto>> GetAllActividadesAsync();
        Task<List<ActividadMensualDto>> GetRegistrosByActividades(int actividad);
        Task<List<ActividadMensualDto>> GetActividadesByArea(int area);
    }

    public class QAMensualProxy : IQAMensualProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QAMensualProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<ActividadMensualDto>> GetAllActividadesAsync()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}planeacion/actividadesMensuales");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<ActividadMensualDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<ActividadMensualDto>> GetRegistrosByActividades(int actividad)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}planeacion/actividadesMensuales/getActividadesByProceso/{actividad}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<ActividadMensualDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<ActividadMensualDto>> GetActividadesByArea(int area)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}planeacion/actividadesMensuales/getActividadesByArea/{area}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<ActividadMensualDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

    }
}
