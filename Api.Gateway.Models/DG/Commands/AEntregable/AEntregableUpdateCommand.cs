using Microsoft.AspNetCore.Http;
using System;

namespace Api.Gateway.Models.DG.Commands.AEntregable
{
    public class AEntregableUpdateCommand
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public int EntregableId { get; set; }
        public int EstatusId { get; set; }
        public IFormFile Archivo { get; set; }
        public string Observaciones { get; set; }
        public Nullable<DateTime> FechaActualizacion { get; set; }

        public int Anio { get; set; }
        public string Mes { get; set; }
        public string Area { get; set; }
        public string Folio { get; set; }
        public string Entregable { get; set; }
    }
}
