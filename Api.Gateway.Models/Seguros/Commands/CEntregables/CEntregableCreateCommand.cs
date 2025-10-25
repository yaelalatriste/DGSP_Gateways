using Microsoft.AspNetCore.Http;
using System;

namespace Api.Gateway.Models.Seguros.Commands.CEntregables
{
    public class CEntregableCreateCommand
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public int ContinuidadId { get; set; }
        public int EstatusId { get; set; }
        public int Expediente { get; set; }
        public string Tipo { get; set; } = null!;
        public Nullable<DateTime> FechaEnvioSP { get; set; }
        public Nullable<decimal> Importe { get; set; }
        public Nullable<bool> Pagado { get; set; }
        public IFormFile Archivo { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
