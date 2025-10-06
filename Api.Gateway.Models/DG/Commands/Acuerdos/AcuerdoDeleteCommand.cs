using System;

namespace Api.Gateway.Models.DG.Commands.Acuerdos
{
    public class AcuerdoDeleteCommand
    {
        public int Id { get; set; }
        public int NumeroAcuerdo { get; set; }
        public DateTime? FechaEliminacion { get; set; }
    }
}
