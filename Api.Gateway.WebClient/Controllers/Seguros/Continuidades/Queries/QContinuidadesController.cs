using Api.Gateway.Proxies.Cendis.Queries.JUsuarios;
using Api.Gateway.Proxies.DGRH.Queries.Empleado;
using Api.Gateway.Proxies.Estatus.Queries.Continuidades;
using Api.Gateway.Proxies.Seguros.Queries.Continuidades;
using Api.Gateway.Proxies.Usuarios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Gateway.WebClient.Controllers.Seguros.Continuidades.Queries
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("seguros/continuidades")]
    public class QContinuidadesController : ControllerBase
    {
        private readonly IQContinuidadProxy _continuidad;
        private readonly IQEmpleadoProxy _empleado;
        private readonly IQEContinuidadesProxy _estatus;
        private readonly IUsuarioProxy _usuario;

        public QContinuidadesController(IQContinuidadProxy continuidad, IQEmpleadoProxy empleado, IQEContinuidadesProxy estatus, IUsuarioProxy usuario)
        {
            _continuidad = continuidad;
            _empleado = empleado;
            _estatus = estatus;
            _usuario = usuario;
        }

        [HttpGet]
        [Route("getAllContinuidades")]
        public async Task<IActionResult> GetAllContinuidades()
        {
            var continuidades = await _continuidad.GetAllContinuidades();
            var empleados = await _empleado.GetAllEmpleados();
            foreach (var cn in continuidades)
            {
                cn.Empleado = empleados.Where(e => e.Expediente == cn.Expediente).First();
                cn.Usuario = await _usuario.GetUsuarioByIdAsync(cn.UsuarioId);
                cn.Estatus = await _estatus.GetEstatusById((int)cn.EstatusId);
            }

            return Ok(continuidades);
        }

        [HttpGet]
        [Route("getContinuidad/{exp}")]
        public async Task<IActionResult> GetContinuidad(int exp)
        {
            var continuidad = await _continuidad.GetContinuidad(exp);
            continuidad.Empleado = await _empleado.GetEmpleadoByExpediente(exp);
            continuidad.Estatus = await _estatus.GetEstatusById((int)continuidad.EstatusId);
            continuidad.Entregables = await _continuidad.GetEntregablesByContinuidad(continuidad.Id);
            continuidad.Correos = await _continuidad.GetCorreosByContinuidad(continuidad.Id);
            continuidad.Oficios = await _continuidad.GetOficiosByContinuidad(continuidad.Id);
            foreach (var e in continuidad.Entregables)
            {
                e.Usuario = await _usuario.GetUsuarioByIdAsync(e.UsuarioId);
            }
            return Ok(continuidad);
        }
    }
}
