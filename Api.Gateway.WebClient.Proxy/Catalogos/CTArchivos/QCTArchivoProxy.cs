using Api.Gateway.Models.Catalogos.DTOs.CTArchivos;
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

namespace Api.Gateway.WebClient.Proxy.Catalogos.CTArchivos
{
    public interface IQCTArchivoProxy
    {
        Task<List<CTArchivoDto>> GetAllArchivosAsync();
        Task<List<CTArchivoDto>> GetArchivosByModuloAsync(int modulo);
        Task<List<CTArchivoDto>> GetArchivosBySubmoduloAsync(int submodulo);
        Task<List<CTArchivoDto>> GetArchivosByModSubAsync(int modulo, int submodulo);
        Task<CTArchivoDto> GetArchivoById(int archivo);
    }

    public class QCTArchivoProxy : IQCTArchivoProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QCTArchivoProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<CTArchivoDto>> GetAllArchivosAsync()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/ctarchivos/getAllArchivos");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTArchivoDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<List<CTArchivoDto>> GetArchivosByModuloAsync(int modulo)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/ctarchivos/getArchivosByModulo/{modulo}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTArchivoDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<List<CTArchivoDto>> GetArchivosBySubmoduloAsync(int submodulo)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/ctarchivos/getArchivosBySubmodulo/{submodulo}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTArchivoDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<List<CTArchivoDto>> GetArchivosByModSubAsync(int modulo, int submodulo)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/ctarchivos/getArchivosByModSub/{modulo}/{submodulo}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTArchivoDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<CTArchivoDto> GetArchivoById(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/ctarchivos/getArchivoById/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<CTArchivoDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
