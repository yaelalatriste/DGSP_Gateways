using Api.Gateway.Models.Catalogos.DTOs.CTArticulos;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.Proxies.Planeacion.Articulos.Queries
{
    public interface IQCTArticuloProxy
    {
        Task<List<CTArticuloDto>> GetAllArticulosAsync();
        Task<List<CTArticuloDto>> GetArticulosByCategoriaAsync(int categoria);
        Task<List<CTArticuloCDto>> GetArticulosAgrupados();
    }

    public class QCTArticuloProxy : IQCTArticuloProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QCTArticuloProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<CTArticuloDto>> GetAllArticulosAsync()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/articulos/getArticulos");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTArticuloDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<CTArticuloDto>> GetArticulosByCategoriaAsync(int categoria)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/articulos/getArticulosByCategoria/{categoria}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTArticuloDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        
        public async Task<List<CTArticuloCDto>> GetArticulosAgrupados()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/articulos/getArticulosAgrupados");
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
