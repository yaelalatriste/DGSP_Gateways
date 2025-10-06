using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Gateway.Models.Planeacion.Commands.ActividadesMensuales
{
    public class ActividadMensualCreateCommand
    {
        public string UsuarioId { get; set; }
        public int Anio { get; set; }
        public int AreaId { get; set; }
        public int MesId { get; set; }
        public int ActividadId { get; set; }
        public int Programado { get; set; }
        public int Adecuado { get; set; }
        public int Realizado { get; set; }
    }
}
