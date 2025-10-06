using Api.Gateway.Models.Catalogos.DTOs.CTAreas;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Catalogos.Service.Queries.DTOs.CTCendi;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Catalogos.CTCendis.Queries
{
    public interface IQCTCendisProxy
    {
        Task<List<CTCendiDto>> GetAllCendisAsync();
        Task<CTCendiDto> GetCendisByIdAsync(int id);
    }

    public class QCTCendisProxy : IQCTCendisProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QCTCendisProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<CTCendiDto>> GetAllCendisAsync()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/cendis/getAllCendis");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTCendiDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<CTCendiDto> GetCendisByIdAsync(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/cendis/getCendisById/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<CTCendiDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
