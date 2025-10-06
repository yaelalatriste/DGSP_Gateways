using Api.Gateway.Models.DG.Commands.AEntregable;
using Api.Gateway.Models.DG.Queries.AEntregable;
using Api.Gateway.Proxies.DG.Commands.AEntregables;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.DG.Entregables.Commands.AEntregables
{
    public interface ICAEntregableProxy
    {
        Task<AEntregableDto> CreateAEntregable(AEntregableCreateCommand command);
        Task<AEntregableDto> UpdateAEntregable(AEntregableUpdateCommand command);
        Task<AEntregableDto> DeleteAEntregable(AEntregableDeleteCommand command);
    }

    public class CAEntregableProxy : ICAEntregableProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public CAEntregableProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<AEntregableDto> CreateAEntregable([FromForm] AEntregableCreateCommand command)
        {
            var formContent = new MultipartFormDataContent();
            if (command.Archivo != null)
            {
                formContent.Add(new StringContent(command.Anio.ToString()), "Anio");
                formContent.Add(new StringContent(command.Mes.ToString()), "Mes");
                formContent.Add(new StringContent(command.Area.ToString()), "Area");
                formContent.Add(new StringContent(command.Folio.ToString()), "Folio");
                formContent.Add(new StringContent(command.Entregable.ToString()), "Entregable");
                var fileStreamContentPDF = new StreamContent(command.Archivo.OpenReadStream());
                fileStreamContentPDF.Headers.ContentType = MediaTypeHeaderValue.Parse(command.Archivo.ContentType);
                formContent.Add(fileStreamContentPDF, name: "Archivo", command.Archivo.FileName);
            }

            formContent.Add(new StringContent(command.UsuarioId.ToString()), "UsuarioId");
            formContent.Add(new StringContent(command.AcuerdoId.ToString()), "AcuerdoId");
            formContent.Add(new StringContent(command.EntregableId.ToString()), "EntregableId");
            formContent.Add(new StringContent(command.Observaciones.ToString()), "Observaciones");

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}dg/entregablesAcuerdos/createAEntregable", formContent);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<AEntregableDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<AEntregableDto> UpdateAEntregable([FromForm] AEntregableUpdateCommand command)
        {
            var formContent = new MultipartFormDataContent();
            if (command.Archivo != null)
            {
                formContent.Add(new StringContent(command.Anio.ToString()), "Anio");
                formContent.Add(new StringContent(command.Mes.ToString()), "Mes");
                formContent.Add(new StringContent(command.Area.ToString()), "Area");
                formContent.Add(new StringContent(command.Folio.ToString()), "Folio");
                formContent.Add(new StringContent(command.Entregable.ToString()), "Entregable");
                var fileStreamContentPDF = new StreamContent(command.Archivo.OpenReadStream());
                fileStreamContentPDF.Headers.ContentType = MediaTypeHeaderValue.Parse(command.Archivo.ContentType);
                formContent.Add(fileStreamContentPDF, name: "Archivo", command.Archivo.FileName);
            }

            formContent.Add(new StringContent(command.Id.ToString()), "Id");
            formContent.Add(new StringContent(command.UsuarioId.ToString()), "UsuarioId");
            formContent.Add(new StringContent(command.EntregableId.ToString()), "EntregableId");
            formContent.Add(new StringContent(command.Observaciones.ToString()), "Observaciones");

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}dg/entregablesAcuerdos/updateAEntregable", formContent);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<AEntregableDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<AEntregableDto> DeleteAEntregable([FromForm] AEntregableDeleteCommand command)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(command),
                 Encoding.UTF8,
                 "application/json"
             );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}dg/entregablesAcuerdos/deleteAEntregable", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<AEntregableDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
