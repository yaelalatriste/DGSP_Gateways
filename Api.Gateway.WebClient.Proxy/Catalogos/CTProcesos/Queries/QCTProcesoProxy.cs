using Api.Gateway.Models.Catalogos.DTOs.CTProcesos;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Planeacion.CTProcesos.Queries
{
    public interface IQCTProcesoProxy
    {
        Task<List<CTPProcesoDto>> GetAllProcesosAsync();
        Task<List<CTPProcesoDto>> GetAllProcesosByAreaAsync(int idArea);
    }

    public class QCTProcesoProxy : IQCTProcesoProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QCTProcesoProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<CTPProcesoDto>> GetAllProcesosAsync()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/ctprocesos");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTPProcesoDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<CTPProcesoDto>> GetAllProcesosByAreaAsync(int idArea)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/ctprocesos/getPProcesosByArea/{idArea}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTPProcesoDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
