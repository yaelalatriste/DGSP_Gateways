using Api.Gateway.Models.Catalogos.DTOs.CTArticulos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Gateway.Models.Catalogos.DTOs.CTCategorias
{
    public class CTCategoriaDto
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Abreviacion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public List<CTArticuloDto> Articulos = new List<CTArticuloDto>();
    }
}
