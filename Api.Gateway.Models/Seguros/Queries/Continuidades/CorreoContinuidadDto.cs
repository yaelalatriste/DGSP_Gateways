using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Models.Seguros.Queries.Continuidades
{
    public class CorreoContinuidadDto
    {
        public int Id { get; set; }
        public int ContinuidadId { get; set; }
        public string Email { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}
