using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Models.Reportes
{
    public class RConsultorioConsultaDto
    {
        public int Id { get; set; }
        public int ConsultorioId { get; set; }
        public string Consultorio { get; set; } = null!;
        public string TipoConsulta { get; set; } = null!;
        public int Total { get; set; }
    }
}
