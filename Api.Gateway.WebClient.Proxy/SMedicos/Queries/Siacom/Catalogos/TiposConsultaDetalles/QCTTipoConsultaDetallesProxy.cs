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

namespace Api.Gateway.WebClient.Proxy.SMedicos.Queries.Siacom.Catalogos.TiposConsultaDetalles
{
    public interface IQCTTipoConsultaDetallesProxy 
    {
        Task<List<CTTipoConsultaDetalleDto>> GetAllTiposConsultaDetalle();
        Task<CTTipoConsultaDetalleDto> GetTipoConsultaDetalleById(int id);
    }
    public class QCTTipoConsultaDetallesProxy : IQCTTipoConsultaDetallesProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QCTTipoConsultaDetallesProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<CTTipoConsultaDetalleDto>> GetAllTiposConsultaDetalle()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}smedicos/tiposConsultaDetalle/getAllTCDetalle");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTTipoConsultaDetalleDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<CTTipoConsultaDetalleDto> GetTipoConsultaDetalleById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}smedicos/tiposConsultaDetalle/getTCDetalleById/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<CTTipoConsultaDetalleDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
