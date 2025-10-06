using System;

namespace Api.Gateway.Models.Cendis.Commands.Justificantes
{
    public class JustificanteDeleteCommand
    {
        public int Id { get; set; }
        public DateTime FechaEliminacion { get; set; }
    }
}
