using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Models.Seguros.Commands.Movimientos
{
    public class OMovimientoCreateCommand
    {
        public int ContinuidadId { get; set; }
        public int Oficio { get; set; }
        public Nullable<DateTime> FechaEnvioBanorte  { get; set; }
        public string? Observaciones { get; set; }
        public Nullable<DateTime> FechaCreacion { get; set; }
    }
}
