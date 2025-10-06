using Api.Gateway.Models.Catalogos.DTOs.CTIncidencias;
using Api.Gateway.Models.Catalogos.DTOs.CTMeses;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Catalogos.CTIncidencias.Queries
{
    public interface IQCTIncidenciasProxy
    {
        Task<List<CTIncidenciaDto>> GetAllCTIncidenciasAsync();
        Task<List<CTIncidenciaDto>> GetCTIncidenciasByTipo(string tipo);
        Task<CTIncidenciaDto> GetCTIncidenciaById(int area);
    }

    public class QCTIncidenciasProxy : IQCTIncidenciasProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QCTIncidenciasProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<CTIncidenciaDto>> GetAllCTIncidenciasAsync()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/incidencias/getAllIncidencias");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTIncidenciaDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<CTIncidenciaDto>> GetCTIncidenciasByTipo(string tipo)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/incidencias/getIncidenciasByTipo/{tipo}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTIncidenciaDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<CTIncidenciaDto> GetCTIncidenciaById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/incidencias/getIncidenciaById/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<CTIncidenciaDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
