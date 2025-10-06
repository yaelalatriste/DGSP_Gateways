using Api.Gateway.Models.Expedientes.DTOs;
using Api.Gateway.Models.Planeacion.Queries.ActividadesMensuales;
using Api.Gateway.Models.Planeacion.Queries.Entregables;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Planeacion.Expedientes.Queries
{
    public interface IQExpedientePlaneacionProxy
    {
        Task<List<ExpedienteDto>> GetAllExpedientes();
        Task<List<ExpedienteDto>> GetExpedientesByAnio(int anio);
        Task<List<ExpedienteDto>> GetExpedientesByCategoria(int categoria);
        Task<List<ExpedienteDto>> GetExpedientesByAnioCategoria(int anio, int categoria);
        Task<ExpedienteDto> GetExpedienteById(int id);
        Task<string> VisualizarEntregable(string area, int anio, string categoria, string entregable, string archivo);
    }

    public class QExpedientePlaneacionProxy : IQExpedientePlaneacionProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QExpedientePlaneacionProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<ExpedienteDto>> GetAllExpedientes()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}planeacion/expedientes/getAllExpedientes");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<ExpedienteDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<ExpedienteDto>> GetExpedientesByAnio(int anio)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}planeacion/expedientes/getExpedientesByAnio/{anio}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<ExpedienteDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<ExpedienteDto>> GetExpedientesByCategoria(int categoria)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}planeacion/expedientes/getExpedientesByCategoria/{categoria}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<ExpedienteDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<ExpedienteDto>> GetExpedientesByAnioCategoria(int anio, int categoria)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}planeacion/expedientes/getExpedientesByAnioCategoria/{anio}/{categoria}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<ExpedienteDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<ExpedienteDto> GetExpedienteById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}planeacion/expedientes/getExpedienteById/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<ExpedienteDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<string> VisualizarEntregable(string area, int anio, string categoria, string entregable, string archivo)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}planeacion/expedientes/visualizarEntregable/{area}/{anio}/{categoria}/{entregable}/{archivo}");
            request.EnsureSuccessStatusCode();

            var contents = await request.Content.ReadAsStringAsync();

            return contents;

        }
    }
}
