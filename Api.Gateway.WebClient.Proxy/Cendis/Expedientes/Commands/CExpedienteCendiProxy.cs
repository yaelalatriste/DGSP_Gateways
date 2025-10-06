using Api.Gateway.Models.Expedientes.Commands;
using Api.Gateway.Models.Expedientes.DTOs;
using Api.Gateway.Models.Planeacion.Queries.Entregables;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Planeacion.Service.EventHandler.Commands.EntregablesAM;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Cendis.Expedientes.Commands
{
    public interface ICExpedienteCendiProxy
    {
        Task<ExpedienteDto> CreateExpediente([FromForm] ExpedienteCreateCommand command);
        Task<ExpedienteDto> UpdateExpediente([FromForm] ExpedienteUpdateCommand command);
        Task<ExpedienteDto> DeleteExpediente([FromBody] ExpedienteDeleteCommand command);
    }

    public class CExpedienteCendiProxy : ICExpedienteCendiProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public CExpedienteCendiProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<ExpedienteDto> CreateExpediente([FromForm] ExpedienteCreateCommand command)
        {
            var formContent = new MultipartFormDataContent();
            formContent.Add(new StringContent(command.UsuarioId.ToString()), "UsuarioId");
            formContent.Add(new StringContent(command.CategoriaId.ToString()), "CategoriaId");
            formContent.Add(new StringContent(command.EntregableId.ToString()), "EntregableId");
            formContent.Add(new StringContent(command.Anio.ToString()), "Anio");
            formContent.Add(new StringContent(command.Observaciones.ToString()), "Observaciones");
            if (command.Archivo != null)
            {
                formContent.Add(new StringContent(command.Area.ToString()), "Area");
                formContent.Add(new StringContent(command.Categoria.ToString()), "Categoria");
                formContent.Add(new StringContent(command.Entregable.ToString()), "Entregable");
                var fileStreamContentPDF = new StreamContent(command.Archivo.OpenReadStream());
                fileStreamContentPDF.Headers.ContentType = MediaTypeHeaderValue.Parse(command.Archivo.ContentType);
                formContent.Add(fileStreamContentPDF, name: "Archivo", command.Archivo.FileName);
            }

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}cendis/expedientes/createExpediente", formContent);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<ExpedienteDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<ExpedienteDto> UpdateExpediente([FromForm] ExpedienteUpdateCommand command)
        {
            var formContent = new MultipartFormDataContent();
            formContent.Add(new StringContent(command.Id.ToString()), "Id");
            formContent.Add(new StringContent(command.UsuarioId.ToString()), "UsuarioId");
            formContent.Add(new StringContent(command.CategoriaId.ToString()), "CategoriaId");
            formContent.Add(new StringContent(command.EntregableId.ToString()), "EntregableId");
            formContent.Add(new StringContent(command.Anio.ToString()), "Anio");
            formContent.Add(new StringContent(command.Observaciones.ToString()), "Observaciones");
            if (command.Archivo != null)
            {
                formContent.Add(new StringContent(command.Area.ToString()), "Area");
                formContent.Add(new StringContent(command.Categoria.ToString()), "Categoria");
                formContent.Add(new StringContent(command.Entregable.ToString()), "Entregable");
                var fileStreamContentPDF = new StreamContent(command.Archivo.OpenReadStream());
                fileStreamContentPDF.Headers.ContentType = MediaTypeHeaderValue.Parse(command.Archivo.ContentType);
                formContent.Add(fileStreamContentPDF, name: "Archivo", command.Archivo.FileName);
            }

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}cendis/expedientes/updateExpediente", formContent);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<ExpedienteDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<ExpedienteDto> DeleteExpediente([FromBody] ExpedienteDeleteCommand command)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(command),
                 Encoding.UTF8,
                 "application/json"
            );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}cendis/expedientes/deleteExpediente", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<ExpedienteDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
