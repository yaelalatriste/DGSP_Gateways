using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Models.Estatus.DTOs.Continuidades
{
    public class EContinuidadDto
    {
        public int Id { get; set; }
        public string Abreviacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Icono { get; set; }
        public string Fondo { get;set; }
        public string FondoHexadecimal { get;set; }
        public int Orden { get;set; }
        public DateTime FechaCreacion { get;set; }
    }
}
