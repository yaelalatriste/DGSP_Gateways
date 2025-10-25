using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Models.Seguros.Commands.CorreosContinuidades
{
    public class CorreoUpdateCommand
    {
        public int Id { get; set; }
        public int ContinuidadId { get;set; }
        public string? Email { get;set; }
        public Nullable<DateTime> FechaCreacion { get; set; }
    }
}
