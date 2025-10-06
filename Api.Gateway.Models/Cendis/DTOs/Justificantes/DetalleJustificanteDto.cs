using Api.Gateway.Models.Catalogos.DTOs.CTIncidencias;
using Api.Gateway.Models.Cendis.DTOs.JUsuarios;
using Api.Gateway.Models.Usuarios.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Models.Cendis.DTOs.Justificantes
{
    public class DetalleJustificanteDto
    {
        public int Id { get; set; }
        public int JustificanteId { get; set; }
        public int UsuarioId { get; set; }
        public int IncidenciaId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Archivo { get; set; }
        public string Observaciones { get; set; }
        public JUsuarioDto Usuario { get; set; } = new JUsuarioDto();
        public CTIncidenciaDto Incidencia { get; set; } = new CTIncidenciaDto();
    }
}
