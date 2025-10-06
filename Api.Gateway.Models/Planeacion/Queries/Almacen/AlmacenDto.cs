using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Gateway.Models.Planeacion.Queries.Almacen
{
    public class AlmacenDto
    {
        public int ArticuloId { get; set; }
        public int CategoriaId { get; set; }
        public int Cantidad { get; set; }
        public int UnidadId { get; set; }
        public DateTime FechaActualizacion { get; set; }

        public string Articulo { get; set; }
        public string Unidad { get; set; }
        public string Categoria { get; set; }
    }
}
