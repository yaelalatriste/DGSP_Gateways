﻿using System;

namespace Api.Gateway.Models.Cendis.Commands.Justificantes
{
    public class JustificanteUpdateCommand
    {
        public int Id { get; set; }
        public int EstatusId { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaActualizacion { get; set; }

    }
}
