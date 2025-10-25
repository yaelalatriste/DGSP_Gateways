using Api.Gateway.Models.Usuarios.DTOs;
using System;
using System.Collections.Generic;

namespace Seguros.Services.Queries.DTOs.Continuidades;

public class CEntregableDto
{
    public int Id { get; set; }
    public string? UsuarioId { get; set; }

    public int ContinuidadId { get; set; }

    public string Tipo { get; set; } = null!;

    public string? Archivo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? FechaActualizacion { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public UsuarioDto Usuario { get; set; } = new UsuarioDto();
}
