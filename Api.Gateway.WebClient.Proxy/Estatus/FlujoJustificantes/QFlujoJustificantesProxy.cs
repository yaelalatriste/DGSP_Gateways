using Api.Gateway.Models.Estatus.DTOs;
using Api.Gateway.Models.Estatus.DTOs.FlujoJustificantes;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Estatus.FlujoJustificantes
{
    public interface IQFlujoJustificantesProxy
    {
        Task<List<FlujoJustificanteDto>> GetAllFlujosJustificantes();
        Task<List<FlujoJustificanteDto>> GetAllFlujoByModulo(int modulo, int submodulo);
        Task<List<FlujoJustificanteDto>> GetFlujoByEstatus(int modulo, int submodulo, int estatus);
    }

    public class QFlujoJustificantesProxy : IQFlujoJustificantesProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QFlujoJustificantesProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<FlujoJustificanteDto>> GetAllFlujosJustificantes()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}estatus/flujoJustificante/getAllFlujosJustificantes");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<FlujoJustificanteDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<FlujoJustificanteDto>> GetAllFlujoByModulo(int modulo, int submodulo)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}estatus/flujoJustificante/getAllFlujoByModulo/{modulo}/{submodulo}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<FlujoJustificanteDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<FlujoJustificanteDto>> GetFlujoByEstatus(int estatus, int modulo, int submodulo)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}estatus/flujoJustificante/getFlujoByEstatus/{estatus}/{modulo}/{submodulo}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<FlujoJustificanteDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
