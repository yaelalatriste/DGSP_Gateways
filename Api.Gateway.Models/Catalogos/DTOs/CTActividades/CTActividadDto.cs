using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Gateway.Models.Catalogos.DTOs.CTActividades
{
    public class CTActividadDto
    {
        public int Id { get; set; }
        public int PProcesoId { get; set; }
        public string Abreviacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Periocidad { get; set; }
        public int Orden { get; set; }
    }
}
