using Api.Gateway.Models.Catalogos.DTOs.CTActividades;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Catalogos.CTActividades.Queries
{

    public interface IQCTActividadProxy
    {
        Task<List<CTActividadDto>> GetAllActividadesAsync();
        Task<List<CTActividadDto>> GetActividadesByProceso(int proceso);
        Task<CTActividadDto> GetActividadById(int proceso);
    }

    public class QCTActividadProxy : IQCTActividadProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QCTActividadProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<CTActividadDto>> GetAllActividadesAsync()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/actividades");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTActividadDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<CTActividadDto>> GetActividadesByProceso(int proceso)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/actividades/getActividadesByProceso/{proceso}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTActividadDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<CTActividadDto> GetActividadById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/actividades/getActividadById/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<CTActividadDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
