using System;

namespace Api.Gateway.Models.DG.Commands.AEntregable
{
    public class AEntregableDeleteCommand
    {
        public int Id { get; set; }
        public DateTime? FechaEliminacion { get; set; }
        public string Area { get; set; }
        public string Folio { get; set; }
        public string Entregable { get; set; }
    }
}
