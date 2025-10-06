using Api.Gateway.Models.Catalogos.DTOs.CTCategorias;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Planeacion.Categorias.Queries
{
    public interface IQCTCategoriaProxy
    {
        Task<List<CTCategoriaDto>> GetAllCategoriasAsync();
        Task<CTCategoriaDto> GetCategoriaByIdAsync(int Categoria);
        Task<List<CTCategoriaDto>> GetCategoriasByTipo(string tipo);
        Task<List<CTCategoriaDto>> GetCategoriasWithArticulos();
    }

    public class QCTCategoriaProxy : IQCTCategoriaProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public QCTCategoriaProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<List<CTCategoriaDto>> GetAllCategoriasAsync()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/categorias/getAllCategorias");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTCategoriaDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        
        public async Task<List<CTCategoriaDto>> GetCategoriasByTipo(string tipo)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/categorias/getCategoriasByTipo/{tipo}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTCategoriaDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<CTCategoriaDto> GetCategoriaByIdAsync(int id)
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/categorias/getCategoriaById/{id}");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<CTCategoriaDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<List<CTCategoriaDto>> GetCategoriasWithArticulos()
        {
            var request = await _httpClient.GetAsync($"{_apiGatewayUrl}catalogos/categorias/getCategoriasWithArticulos");
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<List<CTCategoriaDto>>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
