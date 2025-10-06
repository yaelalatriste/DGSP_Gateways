using Api.Gateway.Models.SMedicos.Queries.Siacom.Catalogos;
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

namespace Api.Gateway.WebClient.Proxy.SMedicos.Queries.Siacom.Catalogos.Consultorios
{
    public interface IQCTConsultorioProxy
    {
        Task<List<CTConsultorioDto>> GetAllConsultorios();
        Task<CTConsultorioDto> GetConsultorioById(int id);
    }
    public class QCTConsultorioProxy : IQCTConsultorioProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QCTConsultorioProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<CTConsultorioDto>> GetAllConsultorios()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}smedicos/consultorios/getAllConsultorios");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTConsultorioDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<CTConsultorioDto> GetConsultorioById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}smedicos/consultorios/getConsultorioById/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<CTConsultorioDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
