using Api.Gateway.Models.Catalogos.DTOs.CTAreas;
using Api.Gateway.Models.Usuarios.DTOs;
using System;

namespace Api.Gateway.Models.Planeacion.Queries.Solicitudes
{
    public class SolicitudDto
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public string UsuarioId { get; set; }
        public int EstatusId { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaAtencion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Nullable<DateTime> FechaActualizacion { get; set; }
        public Nullable<DateTime> FechaEliminacion { get; set; }

        public CTAreaDto Area { get; set; } = new CTAreaDto();
        public UsuarioDto Usuario { get; set; } = new UsuarioDto();
    }
}
