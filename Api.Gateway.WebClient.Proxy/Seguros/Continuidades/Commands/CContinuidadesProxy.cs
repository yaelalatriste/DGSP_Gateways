using Api.Gateway.Models.Seguros.Commands.CEntregables;
using Api.Gateway.Models.Seguros.Commands.Continuidades;
using Api.Gateway.Models.Seguros.Commands.CorreosContinuidades;
using Api.Gateway.Models.Seguros.Commands.Movimientos;
using Api.Gateway.Models.Seguros.Queries.Continuidades;
using Api.Gateway.WebClient.Proxy.Config;
using Api.Gateways.Proxies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seguros.Services.Queries.DTOs.Continuidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Proxy.Seguros.Continuidades.Commands
{
    public interface ICContinuidadesProxy
    {
        Task<ContinuidadDto> CreateSContinuidades([FromBody] ContinuidadCreateCommand command);
        Task<ContinuidadDto> UpdateSContinuidades([FromBody] ContinuidadUpdateCommand command);
        Task<CorreoContinuidadDto> CreateCorreo([FromBody] CorreoCreateCommand command);
        Task<CorreoContinuidadDto> UpdateCorreo([FromBody] CorreoUpdateCommand command);
        Task<OficioMovimientoDto> CreateOficio([FromBody] OMovimientoCreateCommand command);
        Task<CEntregableDto> CreateEntregable([FromForm] CEntregableCreateCommand command);
        Task<CEntregableDto> UpdateEntregable([FromForm] CEntregableUpdateCommand command);
    }   

    public class CContinuidadesProxy : ICContinuidadesProxy
    {
        private readonly string _apiGatewayUrl;
        private readonly HttpClient _httpClient;

        public CContinuidadesProxy(HttpClient httpClient, ApiGatewayUrl apiGatewayUrl, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);

            _httpClient = httpClient;
            _apiGatewayUrl = apiGatewayUrl.Value;
        }

        public async Task<ContinuidadDto> CreateSContinuidades([FromBody] ContinuidadCreateCommand command)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(command),
                 Encoding.UTF8,
                 "application/json"
             );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}seguros/scontinuidades/createScontinuidad", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<ContinuidadDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<ContinuidadDto> UpdateSContinuidades([FromBody] ContinuidadUpdateCommand command)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(command),
                 Encoding.UTF8,
                 "application/json"
             );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}seguros/scontinuidades/updateScontinuidad", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<ContinuidadDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<CorreoContinuidadDto> CreateCorreo([FromBody] CorreoCreateCommand command)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(command),
                 Encoding.UTF8,
                 "application/json"
             );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}seguros/continuidades/createCorreo", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<CorreoContinuidadDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        
        public async Task<CorreoContinuidadDto> UpdateCorreo([FromBody] CorreoUpdateCommand command)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(command),
                 Encoding.UTF8,
                 "application/json"
             );

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}seguros/continuidades/updateCorreo", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<CorreoContinuidadDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
        public async Task<OficioMovimientoDto> CreateOficio([FromBody] OMovimientoCreateCommand command)
        {
            var content = new StringContent(
                 JsonSerializer.Serialize(command),
                 Encoding.UTF8,
                 "application/json"
             );

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}seguros/continuidades/createOficio", content);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<OficioMovimientoDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<CEntregableDto> CreateEntregable([FromForm] CEntregableCreateCommand command)
        {
            var formContent = new MultipartFormDataContent();
            formContent.Add(new StringContent(command.UsuarioId.ToString()), "UsuarioId");
            formContent.Add(new StringContent(command.ContinuidadId.ToString()), "ContinuidadId");
            formContent.Add(new StringContent(command.EstatusId.ToString()), "EstatusId");
            formContent.Add(new StringContent(command.Expediente.ToString()), "Expediente");
            formContent.Add(new StringContent(command.Importe.ToString()), "Importe");
            formContent.Add(new StringContent(command.FechaEnvioSP.ToString()), "FechaEnvioSP");
            formContent.Add(new StringContent(command.Pagado.ToString()), "Pagado");
            formContent.Add(new StringContent(command.Tipo.ToString()), "Tipo");
            if (command.Archivo != null)
            {
                var fileStreamContentPDF = new StreamContent(command.Archivo.OpenReadStream());
                fileStreamContentPDF.Headers.ContentType = MediaTypeHeaderValue.Parse(command.Archivo.ContentType);
                formContent.Add(fileStreamContentPDF, name: "Archivo", command.Archivo.FileName);
            }

            var request = await _httpClient.PostAsync($"{_apiGatewayUrl}seguros/continuidades/createEntregable", formContent);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<CEntregableDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }

        public async Task<CEntregableDto> UpdateEntregable([FromForm] CEntregableUpdateCommand command)
        {
            var formContent = new MultipartFormDataContent();
            formContent.Add(new StringContent(command.UsuarioId.ToString()), "UsuarioId");
            formContent.Add(new StringContent(command.ContinuidadId.ToString()), "ContinuidadId");
            formContent.Add(new StringContent(command.EstatusId.ToString()), "EstatusId");
            formContent.Add(new StringContent(command.Expediente.ToString()), "Expediente");
            formContent.Add(new StringContent(command.Importe.ToString()), "Importe");
            formContent.Add(new StringContent(command.FechaEnvioSP.ToString()), "FechaEnvioSP");
            formContent.Add(new StringContent(command.Pagado.ToString()), "Pagado");
            formContent.Add(new StringContent(command.Tipo.ToString()), "Tipo");
            if (command.Archivo != null)
            {
                var fileStreamContentPDF = new StreamContent(command.Archivo.OpenReadStream());
                fileStreamContentPDF.Headers.ContentType = MediaTypeHeaderValue.Parse(command.Archivo.ContentType);
                formContent.Add(fileStreamContentPDF, name: "Archivo", command.Archivo.FileName);
            }

            var request = await _httpClient.PutAsync($"{_apiGatewayUrl}seguros/continuidades/updateEntregable", formContent);
            request.EnsureSuccessStatusCode();

            return JsonSerializer.Deserialize<CEntregableDto>(
                await request.Content.ReadAsStringAsync(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }
            );
        }
    }
}
