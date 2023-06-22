using Infraestructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Service;

namespace api.cuentas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CuentaController : Controller
    {
        private CuentaService CuentaService;
        private IConfiguration configuration;

        public CuentaController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.CuentaService = new CuentaService(configuration.GetConnectionString("postgresDB"));
        }

        [HttpGet("ListarCuenta")]
        public ActionResult<List<CuentaModel>> listarCuentas()
        {
            var resultado = CuentaService.listarCuenta();
            return Ok(resultado);
        }


        [HttpGet("ConsultarCuenta/{id}")]
        public ActionResult<CuentaModel> consultarCuenta(int id)
        {
            var resultado = this.CuentaService.consultarCuenta(id);
            return Ok(resultado);
        }

        [HttpPost("InsertarCuenta")]
        public ActionResult<string> insertarCuenta(CuentaModel modelo)
        {
            var resultado = this.CuentaService.insertarCuenta(new Infraestructure.Models.CuentaModel
            {
                id_persona = modelo.id_persona,
                nombre_cuenta = modelo.nombre_cuenta,
                numero_cuenta = modelo.numero_cuenta,
                saldo = modelo.saldo,
                limite_saldo = modelo.limite_saldo,
                limite_transferencia = modelo.limite_transferencia,
                estado = modelo.estado
            }
            );
            return Ok(resultado);
        }

        [HttpPut("modificarCuenta/{id}")]
        public ActionResult<string> modificarCuenta(CuentaModel modelo, int id)
        {
            var resultado = this.CuentaService.modificarCuenta(new Infraestructure.Models.CuentaModel
            {
                id_persona = modelo.id_persona,
                nombre_cuenta = modelo.nombre_cuenta,
                numero_cuenta = modelo.numero_cuenta,
                saldo = modelo.saldo,
                limite_saldo = modelo.limite_saldo,
                limite_transferencia = modelo.limite_transferencia,
                estado = modelo.estado

            }, id);
            return Ok(resultado);
        }

        [HttpDelete("eliminarCuenta/{id}")]
        public ActionResult<string> eliminarCuenta(int id)
        {
            var resultado = this.CuentaService.eliminarCuenta(id);
            return Ok(resultado);
        }
    }
}
