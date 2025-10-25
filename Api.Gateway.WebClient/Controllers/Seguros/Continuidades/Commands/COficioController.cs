using Api.Gateway.Models.Seguros.Commands.Movimientos;
using Api.Gateway.Proxies.Seguros.Commands.Continuidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Controllers.Seguros.Continuidades.Commands
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("seguros/continuidades")]
    public class COficioController:ControllerBase
    {
        private readonly ICContinuidadesProxy _continuidad;

        public COficioController(ICContinuidadesProxy continuidad)
        {
            _continuidad = continuidad;
        }

        [HttpPost]
        [Route("createOficio")]
        public async Task<IActionResult> CreateCorreo(OMovimientoCreateCommand command)
        {
            var correo = await _continuidad.CreateOficio(command);

            return Ok(correo);
        }
    }
}
