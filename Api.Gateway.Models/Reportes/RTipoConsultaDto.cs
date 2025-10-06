using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Models.Reportes
{
    public class RTipoConsultaDto
    {
        public int Id { get; set; }
        public int IdTipoConsulta { get; set; }
        public string TipoConsulta { get; set; } = null!;
        public int Total { get; set; }
    }
}
