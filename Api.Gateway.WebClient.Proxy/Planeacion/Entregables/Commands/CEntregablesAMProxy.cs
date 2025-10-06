using Api.Gateway.Models.Planeacion.Queries.Entregables;
using Api.Gateway.WebClient.Proxy.Config;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Planeacion.Service.EventHandler.Commands.EntregablesAM;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Planeacion.Entregables.Commands
{
    public interface ICEntregablesAMProxy
    {
        Task<EntregableAMDto> CreateEntregableAM([FromForm] EntregableAMCreateCommand actividad);
        Task<EntregableAMDto> UpdateEntregableAM([FromForm] EntregableAMUpdateCommand actividad);
        Task<EntregableAMDto> DeleteEntregableAM([FromBody] EntregableAMDeleteCommand actividad);
    }

    public class CEntregablesAMProxy : ICEntregablesAMProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public CEntregablesAMProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<EntregableAMDto> CreateEntregableAM([FromForm] EntregableAMCreateCommand actividad)
        {
            var formContent = new MultipartFormDataContent();

            if (actividad.Archivo != null)
            {
                formContent.Add(new StringContent(actividad.UsuarioId.ToString()), "UsuarioId");
                formContent.Add(new StringContent(actividad.AMensualId.ToString()), "AMensualId");
                formContent.Add(new StringContent(actividad.EntregableId.ToString()), "EntregableId");
                formContent.Add(new StringContent(actividad.Entregable.ToString()), "Entregable");
                formContent.Add(new StringContent(actividad.Proceso.ToString()), "Proceso");
                formContent.Add(new StringContent(actividad.Actividad.ToString()), "Actividad");
                formContent.Add(new StringContent(actividad.Mes.ToString()), "Mes");
                var fileStreamContentPDF = new StreamContent(actividad.Archivo.OpenReadStream());
                fileStreamContentPDF.Headers.ContentType = MediaTypeHeaderValue.Parse(actividad.Archivo.ContentType);
                formContent.Add(fileStreamContentPDF, name: "Archivo", actividad.Archivo.FileName);
            }

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}planeacion/entregablesAM/createEntregableAM", formContent);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<EntregableAMDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<EntregableAMDto> UpdateEntregableAM([FromForm] EntregableAMUpdateCommand actividad)
        {
            var formContent = new MultipartFormDataContent();

            formContent.Add(new StringContent(actividad.Id.ToString()), "Id");
            formContent.Add(new StringContent(actividad.UsuarioId.ToString()), "UsuarioId");
            formContent.Add(new StringContent(actividad.AMensualId.ToString()), "AMensualId");
            formContent.Add(new StringContent(actividad.Entregable.ToString()), "Entregable");
            formContent.Add(new StringContent(actividad.Proceso.ToString()), "Proceso");
            formContent.Add(new StringContent(actividad.Actividad.ToString()), "Actividad");
            formContent.Add(new StringContent(actividad.Mes.ToString()), "Mes");
            formContent.Add(new StringContent(actividad.EntregableId.ToString()), "EntregableId");

            if (actividad.Archivo != null)
            {
                var fileStreamContentPDF = new StreamContent(actividad.Archivo.OpenReadStream());
                fileStreamContentPDF.Headers.ContentType = MediaTypeHeaderValue.Parse(actividad.Archivo.ContentType);
                formContent.Add(fileStreamContentPDF, name: "Archivo", actividad.Archivo.FileName);
            }

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}planeacion/entregablesAM/updateEntregableAM", formContent);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<EntregableAMDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<EntregableAMDto> DeleteEntregableAM([FromBody] EntregableAMDeleteCommand actividad)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(actividad),
                 Encoding.UTF8,
                 "application/json"
            );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}planeacion/entregablesAM/deleteEntregableAM", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<EntregableAMDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
