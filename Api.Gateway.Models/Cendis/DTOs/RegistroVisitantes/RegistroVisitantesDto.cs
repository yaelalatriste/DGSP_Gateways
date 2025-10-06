using Catalogos.Service.Queries.DTOs.CTCendi;
using System;

namespace Api.Gateway.Models.Cendis.DTOs.RegistroVisitantes
{
    public class RegistroVisitantesDto
    {
        public int Id { get; set; }
        public string TipoVisitante { get; set; } = string.Empty;
        public int Expediente { get; set; }
        public int CendiId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Paterno { get; set; } = string.Empty;
        public string Materno { get; set; } = string.Empty;
        public string MotivoVisita { get; set; } = string.Empty;
        public string Identificacion { get; set; } = string.Empty;
        public Nullable<DateTime> FechaVisita { get; set; }
        public Nullable<DateTime> HoraEntrada { get; set; }
        public Nullable<DateTime> HoraSalida { get; set; }
        public string Observaciones { get; set; } = string.Empty;

        public CTCendiDto Cendi { get; set; } = new CTCendiDto();
    }
}
