using System;

namespace Catalogos.Service.Queries.DTOs.CTCendi
{
    public class CTCendiDto
    {
        public int Id { get; set; }
        public string Abreviacion { get; set; }
        public string Nombre { get; set; }
        public string Ubicacion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
