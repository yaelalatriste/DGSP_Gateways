using Api.Gateway.Models.Expedientes.DTOs;
using Api.Gateway.Models.Seguros.Queries.Continuidades;
using Api.Gateway.Proxies.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Seguros.Services.Queries.DTOs.Continuidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.Proxies.Seguros.Queries.Continuidades
{
    public interface IQContinuidadProxy
    {
        Task<List<ContinuidadDto>> GetAllContinuidades();
        Task<ContinuidadDto> GetContinuidad(int exp);
        Task<List<CorreoContinuidadDto>> GetCorreosByContinuidad(int id);
        Task<List<OficioMovimientoDto>> GetOficiosByContinuidad(int id);
        Task<List<CEntregableDto>> GetEntregablesByContinuidad(int id);
    }
    
    public class QContinuidadProxy : IQContinuidadProxy
    {
        private readonly ApiUrls _apiUrls;
        private readonly HttpClient _httpClient;

        public QContinuidadProxy(HttpClient httpClient, IOptions<ApiUrls> apiUrls, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiUrls = apiUrls.Value;
        }

        public Task<List<ContinuidadDto>> GetAllContinuidades() => GetAsync<List<ContinuidadDto>>($"{_apiUrls.SegurosUrl}api/seguros/continuidades/getAllContinuidades");
        public Task<ContinuidadDto> GetContinuidad(int exp) => GetAsync<ContinuidadDto>($"{_apiUrls.SegurosUrl}api/seguros/continuidades/getContinuidad/{exp}");
        public Task<List<CorreoContinuidadDto>> GetCorreosByContinuidad(int id) => GetAsync<List<CorreoContinuidadDto>>($"{_apiUrls.SegurosUrl}api/seguros/continuidades/getCorreosByContinuidad/{id}");
        public Task<List<OficioMovimientoDto>> GetOficiosByContinuidad(int id) => GetAsync<List<OficioMovimientoDto>>($"{_apiUrls.SegurosUrl}api/seguros/continuidades/getOficiosByContinuidad/{id}");
        public Task<List<CEntregableDto>> GetEntregablesByContinuidad(int id) => GetAsync<List<CEntregableDto>>($"{_apiUrls.SegurosUrl}api/seguros/continuidades/getEntregablesByContinuidad/{id}");

        private async Task<T> GetAsync<T>(string url)
        {
            using var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            await using var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(stream, _jsonOptions);
        }

        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };
    }
}
