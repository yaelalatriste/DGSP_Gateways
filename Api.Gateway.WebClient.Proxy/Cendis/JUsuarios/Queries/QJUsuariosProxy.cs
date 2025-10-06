using Api.Gateway.Models.Cendis.DTOs.Justificantes;
using Api.Gateway.Models.Cendis.DTOs.JUsuarios;
using Api.Gateway.Proxies.Cendis.Queries.JUsuarios;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Cendis.JUsuarios.Queries
{
    public interface IQJUsuariosProxy
    {
        Task<List<JUsuarioDto>> GetAllJUsuarios();
        Task<JUsuarioDto> GetJUsuarioById(int id);
        Task<JUsuarioDto> GetJUsuarioByExpediente(int expediente);
    }

    public class QJUsuariosProxy : IQJUsuariosProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QJUsuariosProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<JUsuarioDto>> GetAllJUsuarios()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}cendis/jusuarios/getAllJUsuarios");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<JUsuarioDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<JUsuarioDto> GetJUsuarioById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}cendis/jusuarios/getJUsuarioById/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<JUsuarioDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        
        public async Task<JUsuarioDto> GetJUsuarioByExpediente(int expediente)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}cendis/jusuarios/getJUsuarioByExpediente/{expediente}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<JUsuarioDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
