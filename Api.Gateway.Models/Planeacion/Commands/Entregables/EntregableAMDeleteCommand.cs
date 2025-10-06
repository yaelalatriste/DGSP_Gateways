using System;

namespace Planeacion.Service.EventHandler.Commands.EntregablesAM
{
    public class EntregableAMDeleteCommand
    {
        public int Id { get; set; }
        public int Anio { get; set; }
        public string Proceso { get; set; }
        public string Actividad { get; set; }
        public string Mes { get; set; }
        public string Entregable { get; set; }
        public DateTime FechaEliminacion { get; set; }
    }
}
