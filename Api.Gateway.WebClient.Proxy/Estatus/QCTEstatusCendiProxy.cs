using Api.Gateway.Models.Catalogos.DTOs.CTArticulos;
using Api.Gateway.Models.Cendis.DTOs.Justificantes;
using Api.Gateway.Models.Estatus.DTOs.CTECendis;
using Api.Gateway.Models.Planeacion.Queries.ActividadesMensuales;
using Api.Gateway.Models.Planeacion.Queries.Almacen;
using Api.Gateway.Proxies.Estatus.Queries;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Estatus
{
    public interface IQCTEstatusCendiProxy
    {
        Task<List<CTECendisDto>> GetAllEstatus();
        Task<List<CTECendisDto>> GetEstatusCendis(int modulo, int submodulo);
    }

    public class QCTEstatusCendiProxy : IQCTEstatusCendiProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QCTEstatusCendiProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<CTECendisDto>> GetAllEstatus()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}estatus/cendis/getAllEstatus");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTECendisDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<CTECendisDto> GetEstatusById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}estatus/cendis/getEstatusCendis/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<CTECendisDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<List<CTECendisDto>> GetEstatusCendis(int modulo, int submodulo)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}estatus/cendis/getEstatusCendis/{modulo}/{submodulo}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTECendisDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
