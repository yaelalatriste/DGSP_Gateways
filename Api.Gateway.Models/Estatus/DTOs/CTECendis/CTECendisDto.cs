using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Models.Estatus.DTOs.CTECendis
{
    public class CTECendisDto
    {
        public int Id { get; set; }
        public int? ModuloId { get; set; }
        public int? SubmoduloId { get; set; }
        public int? Orden { get; set; }
        public string Abreviacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Fondo { get; set; }
        public string FondoHexadecimal { get; set; }
        public string Icono { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
