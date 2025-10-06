using Api.Gateway.Models.DG.Queries.Acuerdos;
using Api.Gateway.Models.DG.Queries.AEntregable;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.DG.Entregables.Queries.AEntregables
{
    public interface IQAEntregableProxy
    {
        Task<List<AEntregableDto>> GetAllEntregablesAsync();
        Task<List<AEntregableDto>> GetEntregablesByAcuerdo(int acuerdo);
        Task<AEntregableDto> GetEntregableById(int id);
        Task<string> VisualizarEntregable(int anio, string mes, string area, string folio, string entregable, string archivo);
    }
    
    public class QAEntregableProxy : IQAEntregableProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QAEntregableProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<AEntregableDto>> GetAllEntregablesAsync()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}dg/entregablesAcuerdos");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<AEntregableDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<AEntregableDto>> GetEntregablesByAcuerdo(int acuerdo)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}dg/entregablesAcuerdos/getAEntregableByAcuerdo/{acuerdo}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<AEntregableDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<AEntregableDto> GetEntregableById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}dg/entregablesAcuerdos/getAcuerdoById/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<AEntregableDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<string> VisualizarEntregable(int anio, string mes, string area, string folio, string entregable, string archivo)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}dg/entregablesAcuerdos/visualizarEntregable/{anio}/{mes}/{area}/{folio}/{entregable}/{archivo}");
            request.EnsureSuccessStatusCode();

            var contents = await request.Content.ReadAsStringAsync();

            return contents;

        }
    }
}
