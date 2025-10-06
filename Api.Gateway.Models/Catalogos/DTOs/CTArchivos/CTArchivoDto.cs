using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Models.Catalogos.DTOs.CTArchivos
{
    public class CTArchivoDto
    {
        public int Id { get; set; }
        public int ModuloId { get; set; }
        public int SubmoduloId { get; set; }
        public string Abreviacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
