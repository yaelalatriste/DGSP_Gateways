using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Models.Reportes
{
    public class RConsultorioDto
    {
        public int Id { get;set; }
        public int IdConsultorio { get;set; }
        public string Consultorio { get; set; } = null!;
        public int Total { get;set; }
    }
}
