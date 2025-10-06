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
    public interface IQSContinuidadesProxy
    {
        Task<List<SeguimientoContinuidadDto>> GetAllContinuidades();
        Task<List<SeguimientoContinuidadDto>> GetContinuidadesByUsuario(string usuario);
        Task<SeguimientoContinuidadDto> GetContinuidadById(int id);
    }
    public class QSContinuidadesProxy : IQSContinuidadesProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QSContinuidadesProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<SeguimientoContinuidadDto>> GetAllContinuidades()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}seguros/scontinuidades/getAllContinuidades");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<SeguimientoContinuidadDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<SeguimientoContinuidadDto>> GetContinuidadesByUsuario(string usuario)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}seguros/scontinuidades/getContinuidadesByUsuario/{usuario}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<SeguimientoContinuidadDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<SeguimientoContinuidadDto> GetContinuidadById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}seguros/scontinuidades/getContinuidadById/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<SeguimientoContinuidadDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
