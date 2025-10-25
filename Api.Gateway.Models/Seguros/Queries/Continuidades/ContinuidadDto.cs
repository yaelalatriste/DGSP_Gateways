using Api.Gateway.Models.Catalogos.DTOs.CTEntregables;
using Api.Gateway.Models.DGRH.Empleados;
using Api.Gateway.Models.Estatus.DTOs.Continuidades;
using Api.Gateway.Models.Usuarios.DTOs;
using Seguros.Services.Queries.DTOs.Continuidades;
using System;
using System.Collections.Generic;

namespace Api.Gateway.Models.Seguros.Queries.Continuidades;

public class ContinuidadDto
{
    public int Id { get; set; }

    public string UsuarioId { get; set; } = null!;

    public int? EstatusId { get; set; }

    public int Expediente { get; set; }

    public DateTime? FechaBaja { get; set; }

    public DateTime? FechaEnvioSp { get; set; }

    public decimal? Importe { get; set; }

    public bool? Pagado { get; set; }

    public string? Observaciones { get; set; }
    public bool Editable { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public UsuarioDto Usuario{  get; set; } = new UsuarioDto();
    public EmpleadoDto Empleado {  get; set; } = new EmpleadoDto();
    public EContinuidadDto Estatus {  get; set; } = new EContinuidadDto();
    public List<CEntregableDto> Entregables { get; set; } = new List<CEntregableDto>();
    public List<CorreoContinuidadDto> Correos {  get; set; } = new List<CorreoContinuidadDto>();
    public List<OficioMovimientoDto> Oficios {  get; set; } = new List<OficioMovimientoDto>();
}
