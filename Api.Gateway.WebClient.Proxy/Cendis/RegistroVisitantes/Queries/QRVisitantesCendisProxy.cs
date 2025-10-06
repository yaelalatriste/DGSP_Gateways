using Api.Gateway.Models.Cendis.DTOs.RegistroVisitantes;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Cendis.RegistroVisitantes.Queries
{
    public interface IQRVisitantesCendisProxy
    {
        Task<List<RegistroVisitantesDto>> GetAllRVisitantes();
        Task<List<RegistroVisitantesDto>> GetRVisitantsByDay(string dia);
    }

    public class QRVisitantesCendisProxy : IQRVisitantesCendisProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QRVisitantesCendisProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<RegistroVisitantesDto>> GetAllRVisitantes()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}cendis/registroVisitantes/getAllRVisitantes");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<RegistroVisitantesDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<RegistroVisitantesDto>> GetRVisitantsByDay(string dia)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}cendis/registroVisitantes/getRegistrosByDia/{dia}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<RegistroVisitantesDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
