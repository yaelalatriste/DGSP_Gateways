using Api.Gateway.Models.Catalogos.DTOs.CTMovimientos;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Catalogos.CTMovimientos.Queries
{
    public interface IQCTMovimientoProxy
    {
        Task<List<CTMovimientoDto>> GetAllMovimientos();
        Task<CTMovimientoDto> GetMovimientoById(int id);
    }
    public class QCTMovimientoProxy : IQCTMovimientoProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QCTMovimientoProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<CTMovimientoDto>> GetAllMovimientos()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/movimientos/getAllMovimientos");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTMovimientoDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<CTMovimientoDto> GetMovimientoById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/movimmientos/getMovimientoById/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<CTMovimientoDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
