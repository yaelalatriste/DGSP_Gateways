using Api.Gateway.Models.Usuarios.DTOs;
using System;

namespace Api.Gateway.Models.Seguros.Queries.Continuidades;

public class ContinuidadExcelDto
{
    public int Id { get; set; }

    public string UsuarioId { get; set; } = null!;

    public int Expediente { get; set; }

    public string? ServidorPublico { get; set; }

    public DateTime? FechaBaja { get; set; }

    public string? Oficio { get; set; }

    public int? OficioMovimientos { get; set; }

    public DateTime? FechaEnvioBanorte { get; set; }

    public string CvePuesto { get; set; } = null!;

    public string? Tipo { get; set; }

    public string? Puesto { get; set; }

    public DateTime? FechaEnvioSp { get; set; }

    public decimal? Importe { get; set; }

    public bool? Pagado { get; set; }

    public string? Observaciones { get; set; }

    public string? Estatus { get; set; }

    public bool? Atendido { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }
}
