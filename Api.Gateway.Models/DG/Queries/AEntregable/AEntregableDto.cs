using Api.Gateway.Models.Catalogos.DTOs.CTArchivos;
using Api.Gateway.Models.Catalogos.DTOs.CTAreas;
using Api.Gateway.Models.Estatus.DTOs.Acuerdos;
using Api.Gateway.Models.Usuarios.DTOs;
using System;

namespace Api.Gateway.Models.DG.Queries.AEntregable
{
    public class AEntregableDto
    {
        public int Id { get; set; }
        public int AcuerdoId { get; set; }
        public string? UsuarioId { get; set; }
        public int EntregableId { get; set; }
        public int EstatusId { get; set; }
        public string? Archivo { get; set; }
        public string? Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Nullable<DateTime> FechaActualizacion { get; set; }
        public Nullable<DateTime> FechaEliminacion { get; set; }

        public UsuarioDto Usuario { get; set; } = new UsuarioDto();
        public CTArchivoDto Entregable { get; set; } = new CTArchivoDto();
        public EAcuerdoDto Estatus { get; set; } = new EAcuerdoDto();
    }
}
