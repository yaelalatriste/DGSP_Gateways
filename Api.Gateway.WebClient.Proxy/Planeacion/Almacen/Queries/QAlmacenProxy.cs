using Api.Gateway.Models.Catalogos.DTOs.CTArticulos;
using Api.Gateway.Models.Planeacion.Queries.ActividadesMensuales;
using Api.Gateway.Models.Planeacion.Queries.Almacen;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Planeacion.Almacen.Queries
{
    public interface IQAlmacenProxy
    {
        Task<List<AlmacenDto>> GetAlmacen();
        Task<List<CTArticuloCDto>> GetAlmacenClasificado();
    }

    public class QAlmacenProxy : IQAlmacenProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QAlmacenProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<AlmacenDto>> GetAlmacen()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}planeacion/almacen/getAlmacen");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<AlmacenDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<CTArticuloCDto>> GetAlmacenClasificado()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}planeacion/almacen/getAlmacenClasificado");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTArticuloCDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
