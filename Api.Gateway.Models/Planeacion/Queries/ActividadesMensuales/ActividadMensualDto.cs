using Api.Gateway.Models.Catalogos.DTOs.CTActividades;
using Api.Gateway.Models.Catalogos.DTOs.CTEntregables;
using Api.Gateway.Models.Catalogos.DTOs.CTMeses;
using Api.Gateway.Models.Planeacion.Queries.Entregables;
using Api.Gateway.Models.Usuarios.DTOs;
using System;
using System.Collections.Generic;

namespace Api.Gateway.Models.Planeacion.Queries.ActividadesMensuales
{
    public class ActividadMensualDto
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public int AreaId { get; set; }
        public int Anio { get; set; }
        public int MesId { get; set; }
        public int ActividadId { get; set; }
        public int Programado { get; set; }
        public int Adecuado { get; set; }
        public int Realizado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Nullable<DateTime> FechaActualizacion { get; set; }
        public Nullable<DateTime> FechaEliminacion { get; set; }

        public CTMesDto Mes { get; set; } = new CTMesDto();
        public List<EntregableAMDto> Entregables { get; set; } = new List<EntregableAMDto>();
        public CTActividadDto Actividad { get; set; } = new CTActividadDto();
        public UsuarioDto Usuario { get; set; } = new UsuarioDto();
    }
}
