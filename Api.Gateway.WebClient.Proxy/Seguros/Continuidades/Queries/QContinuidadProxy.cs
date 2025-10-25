using Api.Gateway.Models.Seguros.Queries.Continuidades;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Seguros.Continuidades.Queries
{
    public interface IQContinuidadProxy
    {
        Task<List<ContinuidadDto>> GetAllContinuidades();
        Task<ContinuidadDto> GetContinuidad(int exp);
        Task<List<CorreoContinuidadDto>> GetCorreosByContinuidad(int id);
        Task<List<OficioMovimientoDto>> GetOficiosByContinuidad(int id);
        Task<string> VisualizarEntregable(int expediente, string tipo, string archivo);
    }
    public class QContinuidadProxy : IQContinuidadProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QContinuidadProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public Task<List<ContinuidadDto>> GetAllContinuidades() => GetAsync<List<ContinuidadDto>>($"{_apiGatewayUrl}seguros/continuidades/getAllContinuidades");

        public Task<ContinuidadDto> GetContinuidad(int exp) => GetAsync<ContinuidadDto>($"{_apiGatewayUrl}seguros/continuidades/getContinuidad/{exp}");
        public Task<List<CorreoContinuidadDto>> GetCorreosByContinuidad(int id) => GetAsync<List<CorreoContinuidadDto>>($"{_apiGatewayUrl}seguros/continuidades/getCorreosByContinuidad/{id}");
        public Task<List<OficioMovimientoDto>> GetOficiosByContinuidad(int id) => GetAsync<List<OficioMovimientoDto>>($"{_apiGatewayUrl}seguros/continuidades/getOficiosByContinuidad/{id}");
        public async Task<string> VisualizarEntregable(int expediente, string tipo, string archivo)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}seguros/continuidades/visualizarEntregable/{expediente}/{tipo}/{archivo}");
            request.EnsureSuccessStatusCode();

            var contents = await request.Content.ReadAsStringAsync();

            return contents;

        }

        private async Task<T> GetAsync<T>(string url)
        {
            using var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            await using var stream = await response.Content.ReadAsStreamAsync();
            return JsonSerializer.Deserialize<T>(stream, _jsonOptions);
        }

        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };
    }
}
