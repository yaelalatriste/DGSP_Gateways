using Api.Gateway.Models.Cendis.Commands.Justificantes;
using Api.Gateway.Models.Cendis.Commands.JUsuarios;
using Api.Gateway.Models.Cendis.DTOs.Justificantes;
using Api.Gateway.Models.Cendis.DTOs.JUsuarios;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Cendis.JUsuarios.Commands
{
    public interface ICJUsuariosProxy
    {
        Task<JUsuarioDto> CreateJUsuario([FromBody] JUsuarioCreateCommand command);
        Task<JUsuarioDto> UpdateJUsuario([FromBody] JUsuarioUpdateCommand command);
    }

    public class CJUsuariosProxy : ICJUsuariosProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public CJUsuariosProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<JUsuarioDto> CreateJUsuario([FromBody] JUsuarioCreateCommand command)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(command),
                 Encoding.UTF8,
                 "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}cendis/jusuarios/createJUsuario", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<JUsuarioDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<JUsuarioDto> UpdateJUsuario([FromBody] JUsuarioUpdateCommand command)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(command),
                 Encoding.UTF8,
                 "application/json"
            );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}cendis/jusuarios/updateJUsuario", content);
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
