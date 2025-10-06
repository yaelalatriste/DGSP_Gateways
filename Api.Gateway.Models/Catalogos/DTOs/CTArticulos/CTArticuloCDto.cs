using Api.Gateway.Models.Catalogos.DTOs.CTCategorias;
using System;

namespace Api.Gateway.Models.Catalogos.DTOs.CTArticulos
{
    public class CTArticuloCDto
    {
        public int CategoriaId { get; set; }
        public int TotalElementos { get; set; }

        public CTCategoriaDto Categoria {  get; set; } = new CTCategoriaDto();
    }
}
