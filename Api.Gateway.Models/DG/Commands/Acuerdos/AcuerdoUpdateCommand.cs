using System;

namespace Api.Gateway.Models.DG.Commands.Acuerdos
{
    public class AcuerdoUpdateCommand
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public string ElaboroId { get; set; }
        public Nullable<DateTime> FechaTermino { get; set; }
        public string Responsable { get; set; }
        public int EstatusId { get; set; }
        public Nullable<DateTime> FechaActualizacion { get; set; }
    }
}
