using Api.Gateway.Models.Reportes;
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

namespace Api.Gateway.WebClient.Proxy.SMedicos.Reportes
{
    public interface IQSMReporteProxy
    {
        Task<List<int>> GetAniosOfConsultas();
        Task<List<RConsultaDto>> GetAllConsultas(FiltrosSmDto filtros);
        Task<List<RConsultaDto>> GetConsultasMedicas(FiltrosSmDto filtros);
        Task<List<RConsultaDto>> GetConsultasOdontologicas(FiltrosSmDto filtros);
        Task<List<RConsultaDto>> GetRevisionEnfermeria(FiltrosSmDto filtros);
    }
    
    public class QSMReporteProxy : IQSMReporteProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QSMReporteProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public Task<List<int>> GetAniosOfConsultas() => GetAsync<List<int>>($"{_apiGatewayUrl}smedicos/reportes/getAniosOfConsultas");
        public Task<List<RConsultaDto>> GetAllConsultas(FiltrosSmDto filtros) => PostAsync<RConsultaDto>($"{_apiGatewayUrl}smedicos/reportes/getAllConsultas", filtros);
        public Task<List<RConsultaDto>> GetConsultasMedicas(FiltrosSmDto filtros) => PostAsync<RConsultaDto>($"{_apiGatewayUrl}smedicos/reportes/getConsultasMedicas", filtros);
        public Task<List<RConsultaDto>> GetConsultasOdontologicas(FiltrosSmDto filtros) => PostAsync<RConsultaDto>($"{_apiGatewayUrl}smedicos/reportes/getConsultasOdontologicas", filtros);
        public Task<List<RConsultaDto>> GetRevisionEnfermeria(FiltrosSmDto filtros) => PostAsync<RConsultaDto>($"{_apiGatewayUrl}smedicos/reportes/getRevisionEnfermeria", filtros);

        private async Task<T> GetAsync<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Error calling GET {url}. Status: {response.StatusCode}, Details: {error}");
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(json, _jsonOptions);
        }

        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        private async Task<List<T>> PostAsync<T>(string url, object data)
        {
            var content = new StringContent(
                JsonSerializer.Serialize(data),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<T>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
