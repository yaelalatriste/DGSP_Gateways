using Microsoft.AspNetCore.Http;
using System;

namespace Api.Gateway.Models.Cendis.Commands.DetallesJustificantes
{
    public class DJustificanteCreateCommand
    {
        public int JustificanteId { get; set; }
        public int UsuarioId { get; set; }
        public int IncidenciaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Observaciones { get; set; }
        public IFormFile Archivo { get; set; }
        public string Cendi { get; set; }
        public string Mes { get; set; }
        public int Anio { get; set; }
    }
}
