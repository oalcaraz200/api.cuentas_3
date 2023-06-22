using Infraestructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Service;

namespace api.cuentas.Controllers
{
        
    [ApiController]
    [Route("api/[controller]")]
    public class OperacionesCuentaController : Controller
    {
        private OperacionesService OperacionesService;
        private IConfiguration configuration;

         public OperacionesCuentaController(IConfiguration configuration)
         {
             this.configuration = configuration;
         }

         //public OperacionesCuentaController(OperacionesService OperacionesService)
         //{
         //   this.OperacionesService = OperacionesService;
         //   this.OperacionesService = new OperacionesService(configuration.GetConnectionString("postgresDB"));
         //}





        [HttpPut("{idCuentaOriginal}/Transferir/{idCuentaDestino}")]
        public ActionResult Transferir(int idCuentaOriginal, int idCuentaDestino, int monto)
        {
            try
            {
                var resultado = OperacionesService.Transferir(idCuentaOriginal, idCuentaDestino, monto);

                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred" + ex);
            }

        }

        [HttpPut("Depositar/{idCuentaOriginal}")]
        public ActionResult Depositar(int idCuentaOriginal, int monto)
        {
            try
            {
                var resultado = OperacionesService.Depositar(idCuentaOriginal, monto);

                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        [HttpPut("Extraer/{idCuentaOriginal}")]
        public ActionResult Extraer(int monto, int idCuentaOriginal)
        {
            try
            {
                var resultado = OperacionesService.Extraer(monto, idCuentaOriginal);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        [HttpDelete("Bloquear/{idCuentaOriginal}")]
        public ActionResult Bloquear(int idCuentaOriginal)
        {
            try
            {
                var resultado = OperacionesService.Bloquear(idCuentaOriginal);

                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        [HttpPost("Imprimir/{idCuentaOriginal}")]
        public ActionResult Imprimir(int idCuentaOriginal)
        {
            try
            {
                var resultado = OperacionesService.Imprimir(idCuentaOriginal);

                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred");
            }
        }
    }
}