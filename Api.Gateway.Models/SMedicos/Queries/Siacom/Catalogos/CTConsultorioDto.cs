using System;

namespace Api.Gateway.Models.SMedicos.Queries.Siacom.Catalogos;

public class CTConsultorioDto
{
    public int FiIdConsultorio { get; set; }

    public string FcConsultorio { get; set; } = null!;

    public string FcTipo { get; set; } = null!;

    public int CveInm { get; set; }

    public string FcTelefono { get; set; } = null!;

    public string FcExtension { get; set; } = null!;

    public bool FlEstatus { get; set; }

    public int FiExpReg { get; set; }

    public DateTime FdFchReg { get; set; }

    public Nullable<int> FiExpAct { get; set; }

    public Nullable<DateTime> FdFchAct { get; set; }
}
