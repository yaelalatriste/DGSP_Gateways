using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Models.Reportes
{
    public class FiltrosSmDto
    {
        public List<int> Anios { get; set; } = new List<int>();
        public List<int> Meses { get; set; } = new List<int>();
    }
}
