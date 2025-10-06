using Api.Gateway.Proxies.Seguros.Queries.Continuidades;
using Api.Gateway.Proxies.Usuarios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Controllers.Seguros.Continuidades.Queries
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("seguros/scontinuidades")]
    public class QSContinuidadesController : ControllerBase
    {
        private readonly IQSContinuidadesProxy _scontinuidad;
        private readonly IUsuarioProxy _usuarios;

        public QSContinuidadesController(IQSContinuidadesProxy scontinuidad, IUsuarioProxy usuarios)
        {
            _scontinuidad = scontinuidad;
            _usuarios = usuarios;
        }

        [HttpGet]
        [Route("getAllContinuidades")]
        public async Task<IActionResult> GetAllContinuidades()
        {
            var continuidades = await _scontinuidad.GetAllContinuidades();
            foreach (var c in continuidades)
            {
                c.Usuario = await _usuarios.GetUsuarioByIdAsync(c.UsuarioId);
            }

            return Ok(continuidades);
        }

        [HttpGet]
        [Route("getContinuidadesByUsuario/{usuario}")]
        public async Task<IActionResult> GetContinuidadesByUsuario(string usuario)
        {
            var continuidades = await _scontinuidad.GetContinuidadesByUsuario(usuario);
            foreach (var c in continuidades)
            {
                c.Usuario = await _usuarios.GetUsuarioByIdAsync(c.UsuarioId);
            }
            return Ok(continuidades);
        }

        [HttpGet]
        [Route("getContinuidadById/{id}")]
        public async Task<IActionResult> GetContinuidadById(int id)
        {
            var continuidades = await _scontinuidad.GetContinuidadById(id);
            continuidades.Usuario = await _usuarios.GetUsuarioByIdAsync(continuidades.UsuarioId);

            return Ok(continuidades);
        }
    }
}
