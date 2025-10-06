using System;

namespace Api.Gateway.Models.Planeacion.Commands.Solicitudes
{
    public class SolicitudUpdateCommand 
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public string UsuarioId { get; set; }
        public int EstatusId { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaAtencion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
