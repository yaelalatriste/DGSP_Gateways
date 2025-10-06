using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Models.Reportes
{
    public class RGeneralDto
    {
        public string Consultas { get; set; } = null!;
        public int Total { get;set; }

        //public List<RConsultorioDto> ReporteConsultorios { get; set; } = new List<RConsultorioDto>();
        //public List<RTipoConsultaDto> ReporteTipoConsultas { get; set; } = new List<RTipoConsultaDto>();
        //public List<RConsultorioConsultaDto> ReporteConsultorioConsultas { get; set; } = new List<RConsultorioConsultaDto>();
    }
}
