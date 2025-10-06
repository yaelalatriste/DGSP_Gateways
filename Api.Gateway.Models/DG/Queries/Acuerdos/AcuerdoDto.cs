using Api.Gateway.Models.Catalogos.DTOs.CTAreas;
using Api.Gateway.Models.Catalogos.DTOs.CTMeses;
using Api.Gateway.Models.Estatus.DTOs.Acuerdos;
using Api.Gateway.Models.Usuarios.DTOs;
using System;

namespace Api.Gateway.Models.DG.Queries.Acuerdos
{
    public class AcuerdoDto
    {
        public int Id { get; set; }
        public int AreaId { get; set; }
        public int EstatusId { get; set; }
        public int Anio { get; set; }
        public int MesId { get; set; }
        public string ElaboroId { get; set; }
        public string Folio { get; set; }
        public string Tema { get; set; }
        public string Descripcion { get; set; }
        public Nullable<DateTime> FechaInicio { get; set; }
        public Nullable<DateTime> FechaTermino { get; set; }
        public Nullable<DateTime> FechaCompromiso { get; set; }
        public string Responsable { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Nullable<DateTime> FechaActualizacion { get; set; }
        public Nullable<DateTime> FechaEliminacion { get; set; }

        public CTMesDto Mes { get; set; } = new CTMesDto();
        public UsuarioDto Elaboro { get; set; } = new UsuarioDto();
        public CTAreaDto Area { get; set; } = new CTAreaDto();
        public EAcuerdoDto Estatus { get; set; } = new EAcuerdoDto();
    }
}
