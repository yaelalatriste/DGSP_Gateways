using Microsoft.AspNetCore.Http;
using System;

namespace Api.Gateway.Models.DG.Commands.AEntregable
{
    public class AEntregableCreateCommand
    {
        public int Id { get; set; }
        public int AcuerdoId { get; set; }
        public string UsuarioId { get; set; }
        public int EntregableId { get; set; }
        public int EstatusId { get; set; }
        public IFormFile Archivo { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }

        public int Anio { get; set; }
        public string Mes { get; set; }
        public string Area { get; set; }
        public string Folio { get; set; }
        public string Entregable { get; set; }
    }
}
