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

namespace Api.Gateway.WebClient.Proxy.SMedicos.Queries.Siacom.Catalogos.TiposServicio
{
    public interface IQCTTipoServicioProxy
    {
        Task<List<CTTipoServicioDto>> GetAllTiposServicios();
        Task<CTTipoServicioDto> GetTipoServicioById(int id);
    }
    public class QCTTipoServicioProxy : IQCTTipoServicioProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QCTTipoServicioProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<CTTipoServicioDto>> GetAllTiposServicios()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}smedicos/tiposServicio/getAllTiposServicio");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTTipoServicioDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<CTTipoServicioDto> GetTipoServicioById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}smedicos/tiposServicio/getTipoServicioById/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<CTTipoServicioDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
