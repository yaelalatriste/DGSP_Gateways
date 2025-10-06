using System;
using Api.Gateway.Models.Catalogos.DTOs.CTAsuntos;

namespace Api.Gateway.Models.Catalogos.DTOs.CTExpedientes
{
    public class CTExpedienteDto
    {
        public int Id { get; set; }
        public int AsuntoId { get; set; }
        public string Abreviacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }

        public CTAsuntoDto Asunto { get; set; } = new CTAsuntoDto();
    }
}
