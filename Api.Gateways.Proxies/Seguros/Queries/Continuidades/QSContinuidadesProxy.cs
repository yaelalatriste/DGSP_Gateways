using Api.Gateway.Models.Expedientes.DTOs;
using Api.Gateway.Models.Seguros.Queries.Continuidades;
using Api.Gateway.Proxies.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.Proxies.Seguros.Queries.Continuidades
{
    public interface IQSContinuidadesProxy
    {
        Task<List<SeguimientoContinuidadDto>> GetAllContinuidades();
        Task<List<SeguimientoContinuidadDto>> GetContinuidadesByUsuario(string usuario);
        Task<SeguimientoContinuidadDto> GetContinuidadById(int id);
    }
    
    public class QSContinuidadesProxy : IQSContinuidadesProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;

        public QSContinuidadesProxy(HttpClient httpClient, IOptions<ApiUrls> apiUrls, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiUrls = apiUrls.Value;
        }

        public async Task<List<SeguimientoContinuidadDto>> GetAllContinuidades()
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.SegurosUrl}api/seguros/scontinuidades/getAllContinuidades");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<SeguimientoContinuidadDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<SeguimientoContinuidadDto>> GetContinuidadesByUsuario(string usuario)
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.SegurosUrl}api/seguros/scontinuidades/getContinuidadesByUsuario/{usuario}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<SeguimientoContinuidadDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<SeguimientoContinuidadDto> GetContinuidadById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiUrls.SegurosUrl}api/seguros/scontinuidades/getContinuidadById/{id}");
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
