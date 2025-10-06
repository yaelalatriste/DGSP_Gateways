using Api.Gateway.Models.DG.Commands.Acuerdos;
using Api.Gateway.Models.DG.Queries.Acuerdos;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.DG.Acuerdos.Commands
{
    public interface ICAcuerdoProxy
    {
        Task<AcuerdoDto> CreateAcuerdo([FromBody] AcuerdoCreateCommand command);
        Task<AcuerdoDto> UpdateAcuerdo([FromBody] AcuerdoUpdateCommand command);
        Task<AcuerdoDto> DeleteAcuerdo([FromBody] AcuerdoDeleteCommand command);
    }

    public class CAcuerdoProxy : ICAcuerdoProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public CAcuerdoProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<AcuerdoDto> CreateAcuerdo([FromBody] AcuerdoCreateCommand command)
        {
            var content = new StringContent(
                  JsonSerializer.Serialize(command),
                  Encoding.UTF8,
                  "application/json"
             );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}dg/acuerdos/createAcuerdo", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<AcuerdoDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<AcuerdoDto> UpdateAcuerdo([FromBody] AcuerdoUpdateCommand command)
        {
            var content = new StringContent(
                  JsonSerializer.Serialize(command),
                  Encoding.UTF8,
                  "application/json"
             );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}dg/acuerdos/updateAcuerdo", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<AcuerdoDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<AcuerdoDto> DeleteAcuerdo([FromBody] AcuerdoDeleteCommand command)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(command),
                 Encoding.UTF8,
                 "application/json"
            );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}dg/acuerdos/deleteAcuerdo", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<AcuerdoDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
