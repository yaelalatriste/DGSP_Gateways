using System;

namespace Api.Gateway.Models.Cendis.Commands.RegistroVisitantes
{
    public class RegistroVisitantesUpdateCommand
    {
        public int Id { get; set; }
        public string Observaciones { get; set; } = string.Empty;
    }
}
