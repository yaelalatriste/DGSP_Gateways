using Microsoft.AspNetCore.Http;
using System;

namespace Planeacion.Service.EventHandler.Commands.EntregablesAM
{
    public class EntregableAMCreateCommand
    {
        public string UsuarioId { get; set; }
        public int AMensualId { get; set; }
        public int EntregableId { get; set; }
        public IFormFile Archivo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Nullable<DateTime> FechaActualizacion { get; set; }

        public string Proceso { get; set; }
        public string Actividad { get; set; }
        public string Mes { get; set; }
        public string Entregable { get; set; }
    }
}
