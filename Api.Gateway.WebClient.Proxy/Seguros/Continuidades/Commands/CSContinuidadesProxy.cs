using Api.Gateway.Models.Seguros.Commands.Continuidades;
using Api.Gateway.Models.Seguros.Queries.Continuidades;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Seguros.Continuidades.Commands
{
    public interface ICSContinuidadesProxy
    {
        Task<SeguimientoContinuidadDto> CreateSContinuidades([FromBody] SContinuidadCreateCommand command);
        Task<SeguimientoContinuidadDto> UpdateSContinuidades([FromBody] SContinuidadUpdateCommand command);
    }   

    public class CSContinuidadesProxy : ICSContinuidadesProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public CSContinuidadesProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<SeguimientoContinuidadDto> CreateSContinuidades([FromBody] SContinuidadCreateCommand command)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(command),
                 Encoding.UTF8,
                 "application/json"
             );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}seguros/scontinuidades/createScontinuidad", content);
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

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}seguros/scontinuidades/updateScontinuidad", content);
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
