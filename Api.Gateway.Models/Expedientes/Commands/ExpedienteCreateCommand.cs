using System;
using Microsoft.AspNetCore.Http;

namespace Api.Gateway.Models.Expedientes.Commands
{
    public class ExpedienteCreateCommand
    {
        public required string UsuarioId { get; set; }
        public int CategoriaId { get; set; }
        public int EntregableId { get; set; }
        public int Anio { get; set; }
        public required IFormFile Archivo { get; set; }
        public string  Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }

        public required string Area { get; set; }
        public required string Categoria { get; set; }
        public required string Entregable { get; set; }
    }
}
