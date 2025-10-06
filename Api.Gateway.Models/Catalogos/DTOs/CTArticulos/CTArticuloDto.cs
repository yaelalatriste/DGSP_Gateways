using Api.Gateway.Models.Catalogos.DTOs.CTCategorias;
using System;

namespace Api.Gateway.Models.Catalogos.DTOs.CTArticulos
{
    public class CTArticuloDto
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public CTCategoriaDto Categoria {  get; set; } = new CTCategoriaDto();
    }
}
