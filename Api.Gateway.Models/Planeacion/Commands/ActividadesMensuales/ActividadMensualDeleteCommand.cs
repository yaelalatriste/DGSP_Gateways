using System;

namespace Api.Gateway.Models.Planeacion.Commands.ActividadesMensuales
{
    public class ActividadMensualDeleteCommand
    {
        public int Id { get; set; }
        public int Anio { get; set; }
        public string Proceso { get; set; }
        public string Actividad { get; set; }
        public string Mes { get; set; }
        public string Entregable { get; set; }
    }
}
