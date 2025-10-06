using Api.Gateway.Models.Catalogos.DTOs.CTEntregables;
using Api.Gateway.Models.Usuarios.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Models.Planeacion.Queries.Entregables
{
    public class EntregableAMDto
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public int AMensualId { get; set; }
        public int EntregableId { get; set; }
        public string Archivo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public DateTime? FechaEliminacion { get; set; }

        public CTEntregableDto Entregable { get; set; } = new CTEntregableDto();
        public UsuarioDto Usuario { get; set; } = new UsuarioDto();
    }
}
