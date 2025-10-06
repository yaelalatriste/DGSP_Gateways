using System;

namespace Api.Gateway.Models.DG.Commands.Acuerdos
{
    public class AcuerdoCreateCommand
    {
        public int AreaId { get; set; }
        public int EstatusId { get; set; }
        public string ElaboroId { get; set; }
        public int NumeroAcuerdo { get; set; }
        public string Tema { get; set; }
        public string Descripcion { get; set; }
        public Nullable<DateTime> FechaInicio { get; set; }
        public Nullable<DateTime> FechaTermino { get; set; }
        public Nullable<DateTime> FechaCompromiso { get; set; }
        public string Responsable { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
