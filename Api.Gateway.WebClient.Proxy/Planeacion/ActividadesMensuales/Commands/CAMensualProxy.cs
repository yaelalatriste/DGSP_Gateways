using Api.Gateway.Models.Planeacion.Commands.ActividadesMensuales;
using Api.Gateway.Models.Planeacion.Queries.ActividadesMensuales;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Planeacion.ActividadesMensuales.Commands
{
    public interface ICAMensualProxy
    {
        Task<ActividadMensualDto> CreateActividad([FromBody] ActividadMensualCreateCommand actividad);
        Task<ActividadMensualDto> UpdateActividad([FromBody] ActividadMensualUpdateCommand actividad);
        Task<ActividadMensualDto> DeleteActividad([FromBody] ActividadMensualDeleteCommand actividad);
    }

    public class CAMensualProxy : ICAMensualProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public CAMensualProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<ActividadMensualDto> CreateActividad([FromBody] ActividadMensualCreateCommand actividad)
        {
            var content = new StringContent(
                  JsonSerializer.Serialize(actividad),
                  Encoding.UTF8,
                  "application/json"
             );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}planeacion/actividadesMensuales/createActividad", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<ActividadMensualDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<ActividadMensualDto> UpdateActividad([FromBody] ActividadMensualUpdateCommand actividad)
        {
            var content = new StringContent(
                  JsonSerializer.Serialize(actividad),
                  Encoding.UTF8,
                  "application/json"
             );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}planeacion/actividadesMensuales/updateActividad", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<ActividadMensualDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<ActividadMensualDto> DeleteActividad([FromBody] ActividadMensualDeleteCommand actividad)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(actividad),
                 Encoding.UTF8,
                 "application/json"
            );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}planeacion/actividadesMensuales/deleteActividad", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<ActividadMensualDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
