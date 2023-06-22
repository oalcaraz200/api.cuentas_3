using System.ComponentModel.DataAnnotations;

namespace api.cuentas.Models
{
    public class PersonaModel
    {
        public int id_persona { get; set; }

        public string nombre { get; set; }

        public string apellido { get; set; }

        public string tipo_doc { get; set; }

        public string documento { get; set; }

        public string direccion { get; set; }

        public string telefono { get; set; }

        public string mail { get; set; }

        public string estado { get; set; }
    }
}
