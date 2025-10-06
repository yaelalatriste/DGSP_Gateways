using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Gateway.Models.Planeacion.Queries.Remisiones
{
    public class RemisionDto
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public int NoEnvio { get; set; }
        public int DoctoMaterial { get; set; }
        public int AnioContable { get; set; }
        public string Observaciones { get; set; }
        public decimal CostoTotal { get; set; }
        public DateTime FechaEnvio { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public DateTime FechaImpresion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Nullable<DateTime> FechaActualizacion { get; set; }
        public Nullable<DateTime> FechaEliminacion { get; set; }
    }
}
