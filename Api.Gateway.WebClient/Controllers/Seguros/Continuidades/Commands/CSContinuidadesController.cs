using Api.Gateway.Models.Seguros.Commands.Continuidades;
using Api.Gateway.Proxies.Seguros.Commands.Continuidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Controllers.Seguros.Continuidades.Commands
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("seguros/scontinuidades")]
    public class CSContinuidadesController : ControllerBase
    {
        private readonly ICSContinuidadesProxy _scontinuidad;

        public CSContinuidadesController(ICSContinuidadesProxy scontinuidad)
        {
            _scontinuidad = scontinuidad;
        }

        [Route("createScontinuidad")]
        [HttpPost]
        public async Task<IActionResult> CreateSContinuidad([FromBody] SContinuidadCreateCommand command)
        {
            var expediente = await _scontinuidad.CreateSContinuidades(command);
            if (expediente != null)
            {
                return Ok(expediente);
            }

            return BadRequest();
        }

        [Route("updateScontinuidad")]
        [HttpPut]
        public async Task<IActionResult> UpdateSContinuidad([FromBody] SContinuidadUpdateCommand command)
        {
            var expediente = await _scontinuidad.UpdateSContinuidades(command);
            if (expediente != null)
            {
                return Ok(expediente);
            }

            return BadRequest();
        }
    }
}
