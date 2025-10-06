using Api.Gateway.Models.Catalogos.DTOs.CTArticulos;
using Api.Gateway.Models.Cendis.DTOs.Justificantes;
using Api.Gateway.Models.Planeacion.Queries.ActividadesMensuales;
using Api.Gateway.Models.Planeacion.Queries.Almacen;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Cendis.Justificantes.Queries
{
    public interface IQJustificanteProxy
    {
        Task<List<JustificanteDto>> GetAllJustificantes();
        Task<JustificanteDto> GetJustificanteById(int id);
        Task<List<JustificanteDto>> GetJustificantesByCendi(int cendi);
        Task<List<DetalleJustificanteDto>> GetDetalleJustificante(int justificante);
    }

    public class QJustificanteProxy : IQJustificanteProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QJustificanteProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<JustificanteDto>> GetAllJustificantes()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}cendis/justificantes/getAlljustificantes");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<JustificanteDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<JustificanteDto>> GetJustificantesByCendi(int cendi)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}cendis/justificantes/getJustificantesByCendi/{cendi}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<JustificanteDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<JustificanteDto> GetJustificanteById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}cendis/justificantes/getJustificanteById/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<JustificanteDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<DetalleJustificanteDto>> GetDetalleJustificante(int justificante)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}cendis/justificantes/getDetalleByJustificantes/{justificante}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<DetalleJustificanteDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
