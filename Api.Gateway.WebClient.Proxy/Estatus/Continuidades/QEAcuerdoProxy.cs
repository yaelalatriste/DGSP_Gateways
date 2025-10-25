
using Api.Gateway.Models.Estatus.DTOs.Continuidades;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Estatus.Continuidades
{
    public interface IQEContinuidadesProxy
    {
        Task<List<EContinuidadDto>> GetAllEstatus();
        Task<EContinuidadDto> GetEstatusById(int id);
    }

    public class QEContinuidadesProxy : IQEContinuidadesProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QEContinuidadesProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<EContinuidadDto>> GetAllEstatus()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}estatus/continuidades/getAllEstatus");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<EContinuidadDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<EContinuidadDto> GetEstatusById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}estatus/continuidades/getEstatusById/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<EContinuidadDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
