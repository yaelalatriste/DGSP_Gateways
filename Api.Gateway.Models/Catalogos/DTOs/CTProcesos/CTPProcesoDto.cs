using Api.Gateway.Models.Catalogos.DTOs.CTActividades;
using System.Collections.Generic;

namespace Api.Gateway.Models.Catalogos.DTOs.CTProcesos
{
    public class CTPProcesoDto
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public string Abreviacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        public string Nomenclatura { get; set; }

        public List<CTActividadDto> Actividades { get; set; } = new List<CTActividadDto>();
    }
}
