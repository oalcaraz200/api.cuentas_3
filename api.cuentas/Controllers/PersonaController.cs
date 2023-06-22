using Infraestructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Service;

namespace api.cuentas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : Controller
    {
        private PersonaService personaService;
        private IConfiguration configuration;

        public PersonaController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.personaService = new PersonaService(configuration.GetConnectionString("postgresDB"));
        }
       
        [HttpGet("ListarPersona")]
        public ActionResult<List<PersonaModel>> ListarPersonas()
        {
            var resultado = personaService.listarPersona();
            return Ok(resultado);
        }


        [HttpGet("ConsultarPersona/{id_persona}")]
        public ActionResult<PersonaModel> ConsultarPersona(int id_persona)
        {
            var resultado = this.personaService.consultarPersona(id_persona);
            return Ok(resultado);
        }

        [HttpPost("InsertarPersona")]
        public ActionResult<string> insertarPersona(PersonaModel modelo)
        {
            var resultado = this.personaService.insertarPersona(new Infraestructure.Models.PersonaModel
            {
                nombre = modelo.nombre,
                apellido = modelo.apellido,
                tipo_doc = modelo.tipo_doc,
                documento = modelo.documento,
                direccion = modelo.direccion,
                telefono = modelo.telefono,
                mail = modelo.mail,
                estado = modelo.estado
            }
            );
            return Ok(resultado);
        }

        [HttpPut("modificarPersona/{id_persona}")]
        public ActionResult<string> modificarPersona(PersonaModel modelo, int id_persona)
        {
            var resultado = this.personaService.modificarPersona(new Infraestructure.Models.PersonaModel
            {
                nombre = modelo.nombre,
                apellido = modelo.apellido,
                tipo_doc = modelo.tipo_doc,
                documento = modelo.documento,
                direccion = modelo.direccion,
                telefono = modelo.telefono,
                mail = modelo.mail,
                estado = modelo.estado
            }, id_persona);
            return Ok(resultado);
        }

        [HttpDelete("eliminarPersona/{id_persona}")]
        public ActionResult<string> eliminarPersona(int id_persona)
        {
            var resultado = this.personaService.eliminarPersona(id_persona);
            return Ok(resultado);
        }
    }
}

