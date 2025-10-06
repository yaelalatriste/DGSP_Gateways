using Api.Gateway.Models.Cendis.Commands.RegistroVisitantes;
using Api.Gateway.Models.Cendis.DTOs.RegistroVisitantes;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Cendis.RegistroVisitantes.Commands
{
    public interface ICRVisitantesCendiProxy
    {
        Task<RegistroVisitantesDto> CreateRegistro([FromBody] RegistroVisitantesCreateCommand command);
        Task<RegistroVisitantesDto> UpdateRegistro([FromBody] RegistroVisitantesUpdateCommand command);
    }

    public class CRVisitantesCendiProxy : ICRVisitantesCendiProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public CRVisitantesCendiProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<RegistroVisitantesDto> CreateRegistro([FromBody] RegistroVisitantesCreateCommand command)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(command),
                 Encoding.UTF8,
                 "application/json"
             );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}cendis/registroVisitantes/createRegistro", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<RegistroVisitantesDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        
        public async Task<RegistroVisitantesDto> UpdateRegistro([FromBody] RegistroVisitantesUpdateCommand command)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(command),
                 Encoding.UTF8,
                 "application/json"
             );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}cendis/registroVisitantes/updateRegistro", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<RegistroVisitantesDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
