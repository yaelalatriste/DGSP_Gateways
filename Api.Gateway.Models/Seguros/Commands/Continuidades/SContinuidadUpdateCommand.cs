using System;

namespace Api.Gateway.Models.Seguros.Commands.Continuidades
{
    public class SContinuidadUpdateCommand
    {
        public int Id { get; set; }

        public string UsuarioId { get; set; } = null!;

        public int Expediente { get; set; }

        public string ServidorPublico { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Asunto { get; set; } = null!;

        public Nullable<DateTime> FechaActualizacion { get; set; }
    }
}
