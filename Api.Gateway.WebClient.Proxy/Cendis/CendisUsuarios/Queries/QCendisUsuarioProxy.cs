using Api.Gateway.Models.Cendis.DTOs.CendisUsuarios;
using Api.Gateway.Models.Cendis.DTOs.Justificantes;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Cendis.CendisUsuarios.Queries
{
    public interface IQCendisUsuarioProxy
    {
        Task<List<CendisUsuarioDto>> GetAllCendisUsuarios();
        Task<List<CendisUsuarioDto>> GetCendisByUsuario(string usuario);
        Task<List<CendisUsuarioDto>> GetUsuariosByCendi(int cendi);
    }

    public class QCendisUsuarioProxy : IQCendisUsuarioProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QCendisUsuarioProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<CendisUsuarioDto>> GetAllCendisUsuarios()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}cendis/cendisUsuarios/getAllCendisUsuarios");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CendisUsuarioDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<CendisUsuarioDto>> GetCendisByUsuario(string usuario)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}cendis/cendisUsuarios/getCendisByUsuario/{usuario}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CendisUsuarioDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<CendisUsuarioDto>> GetUsuariosByCendi(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}cendis/cendisUsuarios/getUsuariosByCendi/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CendisUsuarioDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
