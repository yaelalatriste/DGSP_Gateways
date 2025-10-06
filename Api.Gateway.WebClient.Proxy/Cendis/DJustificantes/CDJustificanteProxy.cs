using Api.Gateway.Models.Catalogos.DTOs.CTArticulos;
using Api.Gateway.Models.Cendis.Commands.DetallesJustificantes;
using Api.Gateway.Models.Cendis.DTOs.Justificantes;
using Api.Gateway.Models.Planeacion.Queries.ActividadesMensuales;
using Api.Gateway.Models.Planeacion.Queries.Almacen;
using Api.Gateway.WebClient.Proxy.Cendis.Justificantes.Queries;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Cendis.DJustificantes
{
    public interface ICDJustificanteProxy
    {
        Task<DetalleJustificanteDto> CreateDJustificante([FromForm] DJustificanteCreateCommand actividad);
        Task<DetalleJustificanteDto> UpdateDJustificante([FromForm] DJustificanteUpdateCommand actividad);
        Task<DetalleJustificanteDto> DeleteDJustificante([FromBody] DJustificanteDeleteCommand actividad);
    }

    public class CDJustificanteProxy : ICDJustificanteProxy
    {

        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public CDJustificanteProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<DetalleJustificanteDto> CreateDJustificante([FromForm] DJustificanteCreateCommand command)
        {
            var formContent = new MultipartFormDataContent();
            formContent.Add(new StringContent(command.JustificanteId.ToString()), "JustificanteId");
            formContent.Add(new StringContent(command.UsuarioId.ToString()), "UsuarioId");
            formContent.Add(new StringContent(command.IncidenciaId.ToString()), "IncidenciaId");
            formContent.Add(new StringContent(command.FechaInicio.ToString()), "FechaInicio");
            formContent.Add(new StringContent(command.FechaFin.ToString()), "FechaFin");
            formContent.Add(new StringContent(command.Observaciones.ToString()), "Observaciones");
            if (command.Archivo != null)
            {
                formContent.Add(new StringContent(command.Cendi.ToString()), "Cendi");
                formContent.Add(new StringContent(command.Mes.ToString()), "Mes");
                formContent.Add(new StringContent(command.Anio.ToString()), "Anio");
                var fileStreamContentPDF = new StreamContent(command.Archivo.OpenReadStream());
                fileStreamContentPDF.Headers.ContentType = MediaTypeHeaderValue.Parse(command.Archivo.ContentType);
                formContent.Add(fileStreamContentPDF, name: "Archivo", command.Archivo.FileName);
            }

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}cendis/detalleJustificantes/createDJustificante", formContent);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DetalleJustificanteDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<DetalleJustificanteDto> UpdateDJustificante([FromForm] DJustificanteUpdateCommand command)
        {
            var formContent = new MultipartFormDataContent();
            formContent.Add(new StringContent(command.Id.ToString()), "Id");
            formContent.Add(new StringContent(command.JustificanteId.ToString()), "JustificanteId");
            formContent.Add(new StringContent(command.UsuarioId.ToString()), "UsuarioId");
            formContent.Add(new StringContent(command.IncidenciaId.ToString()), "IncidenciaId");
            formContent.Add(new StringContent(command.FechaInicio.ToString()), "FechaInicio");
            formContent.Add(new StringContent(command.FechaFin.ToString()), "FechaFin");
            formContent.Add(new StringContent(command.Observaciones.ToString()), "Observaciones");
            if (command.Archivo != null)
            {
                formContent.Add(new StringContent(command.Cendi.ToString()), "Cendi");
                formContent.Add(new StringContent(command.Mes.ToString()), "Mes");
                formContent.Add(new StringContent(command.Anio.ToString()), "Anio");
                var fileStreamContentPDF = new StreamContent(command.Archivo.OpenReadStream());
                fileStreamContentPDF.Headers.ContentType = MediaTypeHeaderValue.Parse(command.Archivo.ContentType);
                formContent.Add(fileStreamContentPDF, name: "Archivo", command.Archivo.FileName);
            }

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}cendis/detalleJustificantes/updateDJustificante", formContent);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DetalleJustificanteDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<DetalleJustificanteDto> DeleteDJustificante([FromBody] DJustificanteDeleteCommand command)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(command),
                 Encoding.UTF8,
                 "application/json"
             );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}cendis/detalleJustificantes/deleteDJustificantes", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<DetalleJustificanteDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
