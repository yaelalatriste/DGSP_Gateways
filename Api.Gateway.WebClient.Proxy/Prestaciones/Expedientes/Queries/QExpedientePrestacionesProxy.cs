using Api.Gateway.Models.Expedientes.DTOs;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Prestaciones.Expedientes.Queries
{
    public interface IQExpedientePrestacionesProxy
    {
        Task<List<ExpedienteDto>> GetAllExpedientes();
        Task<List<ExpedienteDto>> GetExpedientesByAnio(int anio);
        Task<List<ExpedienteDto>> GetExpedientesByCategoria(int categoria);
        Task<List<ExpedienteDto>> GetExpedientesByAnioCategoria(int anio, int categoria);
        Task<ExpedienteDto> GetExpedienteById(int id);
        Task<string> VisualizarEntregable(string area, int anio, string categoria, string entregable, string archivo);
    }

    public class QExpedientePrestacionesProxy : IQExpedientePrestacionesProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QExpedientePrestacionesProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<ExpedienteDto>> GetAllExpedientes()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}prestaciones/expedientes/getAllExpedientes");
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
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}prestaciones/expedientes/getExpedientesByAnio/{anio}");
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
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}prestaciones/expedientes/getExpedientesByCategoria/{categoria}");
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
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}prestaciones/expedientes/getExpedientesByAnioCategoria/{anio}/{categoria}");
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
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}prestaciones/expedientes/getExpedienteById/{id}");
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
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}prestaciones/expedientes/visualizarEntregable/{area}/{anio}/{categoria}/{entregable}/{archivo}");
            request.EnsureSuccessStatusCode();

            var contents = await request.Content.ReadAsStringAsync();

            return contents;

        }
    }
}
