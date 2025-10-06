using Api.Gateway.Models.Expedientes.DTOs;
using Api.Gateway.Models.Seguros.Queries.Reportes;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Seguros.Reportes.Queries
{
    public interface IQRJubiladosProxy
    {
        Task<List<RJubiladoDto>> GetReporteFemenino();
        Task<List<RJubiladoDto>> GetReporteMasculinos();
    }

    public class QRJubiladosProxy : IQRJubiladosProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QRJubiladosProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<RJubiladoDto>> GetReporteFemenino()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}seguros/reportes/jubilados/getRJubiladosFemenino");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<RJubiladoDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<RJubiladoDto>> GetReporteMasculinos()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}seguros/reportes/jubilados/getRJubiladosMasculino");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<RJubiladoDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
