using Api.Gateway.Models.DG.Queries.Acuerdos;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.DG.Acuerdos.Queries
{
    public interface IQAcuerdoProxy
    {
        Task<List<AcuerdoDto>> GetAllAcuerdos();
        Task<AcuerdoDto> GetAcuerdoById(int id);
    }

    public class QAcuerdoProxy : IQAcuerdoProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QAcuerdoProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<AcuerdoDto>> GetAllAcuerdos()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}dg/acuerdos/getAllAcuerdos");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<AcuerdoDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<AcuerdoDto> GetAcuerdoById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}dg/acuerdos/getAcuerdoById/{id}");
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
