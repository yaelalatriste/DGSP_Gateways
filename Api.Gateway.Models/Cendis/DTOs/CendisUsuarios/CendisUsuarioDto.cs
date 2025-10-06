using Catalogos.Service.Queries.DTOs.CTCendi;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Gateway.Models.Cendis.DTOs.CendisUsuarios
{
    public class CendisUsuarioDto
    {
        public required string UsuarioId { get; set; }
        public int CendiId { get; set; }

        public CTCendiDto Cendi { get; set; } = new CTCendiDto();
    }
}
