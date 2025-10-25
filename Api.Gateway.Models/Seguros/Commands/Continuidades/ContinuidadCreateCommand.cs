using System;

namespace Api.Gateway.Models.Seguros.Commands.Continuidades
{
    public class ContinuidadCreateCommand
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; } = null!;
        public int Expediente { get; set; }
        public int EstatusId { get; set; }
        public Nullable<DateTime> FechaCreacion { get; set; }
    }
}
