using Api.Gateway.Models.Catalogos.DTOs.CTArticulos;
using System.Collections.Generic;

namespace Api.Gateway.Models.Planeacion.Queries.Solicitudes
{
    public class DashboardSDto
    {
        public List<SolicitudDto> Solicitud { get; set; } = new List<SolicitudDto>();
        public List<CTArticuloDto> Articulos { get; set; } = new List<CTArticuloDto>();
    }
}
