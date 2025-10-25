using System;

namespace Api.Gateway.Models.Seguros.Commands.Continuidades
{
    public class ContinuidadUpdateCommand
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; } = null!;
        public int Expediente { get; set; }
        public int EstatusId { get; set; }
        public Nullable<DateTime> FechaBaja { get; set; }
        public Nullable<DateTime> FechaEnvioSP { get; set; }
        public Nullable<decimal> Importe { get; set; }
        public Nullable<bool> Pagado { get; set; }
        public Nullable<DateTime> FechaActualizacion { get; set; }
    }
}
