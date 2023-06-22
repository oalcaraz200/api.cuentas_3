using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class PersonaService
    {
        private PersonaRepository repositoryPersona;

        public PersonaService(string connectionString)
        {
            this.repositoryPersona = new PersonaRepository(connectionString);
        }

        public string insertarPersona(PersonaModel persona)
        {
            return validarDatosPersona(persona) ? repositoryPersona.insertarPersona(persona) : throw new Exception("Error en la validacion");
        }

        public string modificarPersona(PersonaModel persona, int id)
        {
            if (repositoryPersona.consultarPersona(id) != null)
                return validarDatosPersona(persona) ?
                    repositoryPersona.modificarPersona(persona, id) :
                    throw new Exception("Error en la validacion");
            else
                return "No se encontraron los datos de esta persona";
        }

        public string eliminarPersona(int id)
        {
            return repositoryPersona.eliminarPersona(id);
        }

        public PersonaModel consultarPersona(int id)
        {
            return repositoryPersona.consultarPersona(id);
        }

        public IEnumerable<PersonaModel> listarPersona()
        {
            return repositoryPersona.listarPersona();
        }

        private bool validarDatosPersona(PersonaModel persona)
        {
            //if (persona.Nombre.Trim().Length < 2)
            //{
            //    return false;
            //}

            return true;
        }

    }
}
