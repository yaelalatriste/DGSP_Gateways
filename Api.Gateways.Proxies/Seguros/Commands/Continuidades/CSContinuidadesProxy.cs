using Api.Gateway.Models.Expedientes.Commands;
using Api.Gateway.Models.Expedientes.DTOs;
using Api.Gateway.Models.Seguros.Commands.Continuidades;
using Api.Gateway.Models.Seguros.Queries.Continuidades;
using Api.Gateway.Proxies.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.Proxies.Seguros.Commands.Continuidades
{
    public interface ICSContinuidadesProxy
    {
        Task<SeguimientoContinuidadDto> CreateSContinuidades([FromBody] SContinuidadCreateCommand command);
        Task<SeguimientoContinuidadDto> UpdateSContinuidades([FromBody] SContinuidadUpdateCommand command);
    }

    public  class CSContinuidadesProxy : ICSContinuidadesProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;

        public CSContinuidadesProxy(HttpClient httpClient, IOptions<ApiUrls> apiUrls, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiUrls = apiUrls.Value;
        }

        public async Task<SeguimientoContinuidadDto> CreateSContinuidades([FromBody] SContinuidadCreateCommand command)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(command),
                 Encoding.UTF8,
                 "application/json"
             );

            var request = await _httpClient.PostAsync($"{_apiUrls.SegurosUrl}api/seguros/scontinuidades/createScontinuidad", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<SeguimientoContinuidadDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<SeguimientoContinuidadDto> UpdateSContinuidades([FromBody] SContinuidadUpdateCommand command)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(command),
                 Encoding.UTF8,
                 "application/json"
             );

            var request = await _httpClient.PutAsync($"{_apiUrls.SegurosUrl}api/seguros/scontinuidades/updateScontinuidad", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<SeguimientoContinuidadDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
