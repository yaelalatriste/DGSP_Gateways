using System;

namespace Api.Gateway.Models.Planeacion.Commands.Solicitudes
{
    public class SolicitudDeleteCommand
    {
        public int Id { get; set; }
        public DateTime FechaEliminacion { get; set; }
    }
}
