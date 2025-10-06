using Api.Gateway.Models.Cendis.Commands.Justificantes;
using Api.Gateway.Models.Cendis.DTOs.Justificantes;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Cendis.Justificantes.Commands
{
    public interface ICJustificanteProxy
    {
        Task<JustificanteDto> CreateJustificante([FromBody] JustificanteCreateCommand command);
        Task<JustificanteDto> UpdateJustificante([FromBody] JustificanteUpdateCommand command);
        Task<JustificanteDto> DeleteJustificante([FromBody] JustificanteDeleteCommand command);
    }

    public class CJustificanteProxy : ICJustificanteProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public CJustificanteProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<JustificanteDto> CreateJustificante([FromBody] JustificanteCreateCommand command)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(command),
                 Encoding.UTF8,
            "application/json"
            );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}cendis/justificantes/createJustificante", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<JustificanteDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<JustificanteDto> UpdateJustificante([FromBody] JustificanteUpdateCommand command)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(command),
                 Encoding.UTF8,
            "application/json"
            );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}cendis/justificantes/updateJustificante", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<JustificanteDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<JustificanteDto> DeleteJustificante([FromBody] JustificanteDeleteCommand command)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(command),
                 Encoding.UTF8,
                 "application/json"
            );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}cendis/justificantes/deleteJustificante", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<JustificanteDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
