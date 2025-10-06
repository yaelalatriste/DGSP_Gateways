using Api.Gateway.Models.Catalogos.DTOs.CTArticulos;
using Api.Gateway.Models.Cendis.DTOs.Justificantes;
using Api.Gateway.Models.Cendis.DTOs.Logs.Justificantes;
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
    public interface IQLJustificanteProxy
    {
        Task<List<LogJustificanteDto>> GetLogJustificantesAsync();
        Task<List<LogJustificanteDto>> GetLogByJustificanteId(int justificante);
    }

    public class QLJustificanteProxy : IQLJustificanteProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QLJustificanteProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<LogJustificanteDto>> GetLogJustificantesAsync()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}cendis/logs/justificantes/getAllLogsJustificantes");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<LogJustificanteDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<LogJustificanteDto>> GetLogByJustificanteId(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}cendis/logs/justificantes/getLogByJustificanteId/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<LogJustificanteDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

    }
}
