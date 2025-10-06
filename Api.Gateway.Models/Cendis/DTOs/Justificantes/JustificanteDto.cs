using Api.Gateway.Models.Catalogos.DTOs.CTMeses;
using Api.Gateway.Models.Estatus.DTOs.CTECendis;
using Api.Gateway.Models.Usuarios.DTOs;
using Catalogos.Service.Queries.DTOs.CTCendi;
using System;

namespace Api.Gateway.Models.Cendis.DTOs.Justificantes
{
    public class JustificanteDto
    {
        public int Id { get; set; }
        public string UsuarioId { get; set; }
        public int CendiId { get; set; }
        public int EstatusId { get; set; }
        public int Anio { get; set; }
        public int MesId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public UsuarioDto Usuario { get; set; } = new UsuarioDto();
        public CTCendiDto Cendi { get; set; } = new CTCendiDto();
        public CTECendisDto Estatus { get; set; } = new CTECendisDto();
        public CTMesDto Mes{ get; set; } = new CTMesDto();
    }
}
