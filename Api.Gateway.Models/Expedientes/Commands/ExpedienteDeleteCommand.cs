using System;

namespace Api.Gateway.Models.Expedientes.Commands
{
    public class ExpedienteDeleteCommand
    {
        public int Id { get; set; }
        public DateTime FechaEliminacion { get; set; }
        public required string Area { get; set; }
        public required string Categoria { get; set; }
        public required string Entregable { get; set; }
    }
}
