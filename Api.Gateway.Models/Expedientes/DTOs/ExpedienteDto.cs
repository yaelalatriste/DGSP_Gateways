using System;
using Api.Gateway.Models.Catalogos.DTOs.CTCategorias;
using Api.Gateway.Models.Catalogos.DTOs.CTExpedientes;
using Api.Gateway.Models.Usuarios.DTOs;

namespace Api.Gateway.Models.Expedientes.DTOs
{
    public class ExpedienteDto
    {
        public int Id { get; set; }
        public required string UsuarioId { get; set; }
        public int CategoriaId { get; set; }
        public int EntregableId { get; set; }
        public int Anio { get; set; }
        public string Archivo { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Nullable<DateTime> FechaActualizacion { get; set; }
        public Nullable<DateTime> FechaEliminacion { get; set; }

        public UsuarioDto Usuario { get; set; } = new UsuarioDto();
        public CTCategoriaDto Categoria { get; set; } = new CTCategoriaDto();
        public CTExpedienteDto Expediente { get; set; } = new CTExpedienteDto();

    }
}
