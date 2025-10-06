using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Gateway.Models.Catalogos.DTOs.CTEntregables
{
    public class CTEntregableDto
    {
        public int Id { get; set; }
        public int ActividadId { get; set; }
        public string Abreviacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Corresponde { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}
