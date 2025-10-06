using System;

namespace Api.Gateway.Models.Cendis.Commands.DetallesJustificantes
{
    public class DJustificanteDeleteCommand
    {
        public int Id { get; set; }
        public string Observaciones { get; set; }
        public string Cendi { get; set; }
        public string Mes { get; set; }
        public int Anio { get; set; }
    }
}
