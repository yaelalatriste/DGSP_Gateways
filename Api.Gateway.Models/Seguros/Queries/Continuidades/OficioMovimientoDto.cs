using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Models.Seguros.Queries.Continuidades
{
    public class OficioMovimientoDto
    {
        public int ContinuidadId { get; set; }
        public int Oficio { get; set; }
        public DateTime? FechaEnvioBanorte { get; set; }
        public string Observaciones { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
