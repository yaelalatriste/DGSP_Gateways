using Api.Gateway.Models.Planeacion.Queries.ActividadesMensuales;
using Api.Gateway.Models.Planeacion.Queries.Entregables;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Planeacion.Entregables.Queries
{
    public interface IQEntregablesAMProxy
    {
        Task<List<EntregableAMDto>> GetAllEntregables();
        Task<List<EntregableAMDto>> GetEntregablesAMByActividad(int actividad);
        Task<string> VisualizarEntregable(int anio, string proceso, string actividad, string mes, string entregable, string archivo);
    }

    public class QEntregablesAMProxy : IQEntregablesAMProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QEntregablesAMProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<EntregableAMDto>> GetAllEntregables()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}planeacion/entregablesAM/getAllEntregablesAM");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<EntregableAMDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<EntregableAMDto>> GetEntregablesAMByActividad(int actividad)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}planeacion/entregablesAM/getEntregablesAMByActividad/{actividad}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<EntregableAMDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<string> VisualizarEntregable(int anio, string proceso, string actividad, string mes, string entregable, string archivo)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}planeacion/entregablesAM/visualizarEntregable/{anio}/{proceso}/{actividad}/{mes}/{entregable}/{archivo}");
            request.EnsureSuccessStatusCode();

            var contents = await request.Content.ReadAsStringAsync();

            return contents;

        }
    }
}
