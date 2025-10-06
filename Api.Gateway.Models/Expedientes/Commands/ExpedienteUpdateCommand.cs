using System;
using Microsoft.AspNetCore.Http;

namespace Api.Gateway.Models.Expedientes.Commands
{
    public class ExpedienteUpdateCommand
    {
        public int Id { get; set; }
        public required string UsuarioId { get; set; }
        public int CategoriaId { get; set; }
        public int EntregableId { get; set; }
        public int Anio { get; set; }
        public IFormFile  Archivo { get; set; }
        public string  Observaciones { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public string Area { get; set; }
        public string Categoria { get; set; }
        public string Entregable { get; set; }
    }
}
