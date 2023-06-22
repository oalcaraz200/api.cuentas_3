using Dapper;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class PersonaRepository
    {

        private string _connectionString;
        private Npgsql.NpgsqlConnection connection;
        public PersonaRepository(string connectionString)
        {
            _connectionString = connectionString;
            connection = new Npgsql.NpgsqlConnection(_connectionString);
        }

        public PersonaModel consultarPersona(int id_persona)
        {
            try
            {
                return connection.QueryFirst<PersonaModel>($"SELECT * FROM persona WHERE id_persona = {id_persona}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string insertarPersona(PersonaModel persona)
        {
            try
            {
                connection.Execute("insert into persona (nombre, apellido, tipo_doc, documento, direccion, telefono, mail, estado) " +
                    " values(@nombre, @apellido, @tipo_doc, @documento, @direccion, @telefono, @mail, @estado)", persona
                    );
                return "Se inserto correctamente...";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public string eliminarPersona(int id_persona)
        {
            try
            {
                connection.Execute($" DELETE FROM persona WHERE id_persona = {id_persona}");
                return "Se eliminó correctamente el registro...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string modificarPersona(PersonaModel persona, int id_persona)
        {
            try
            {

                connection.Execute($"UPDATE persona SET " +
                    "nombre = @nombre, " +
                    "apellido = @apellido, " +
                    "tipo_doc = @tipo_doc, " +
                    "documento = @documento, " +
                    "direccion = @direccion, " +
                    "telefono = @telefono, " +
                    "mail = @mail, " +
                    "estado = @estado " +
                    $"WHERE id_persona= {id_persona}", persona);
                return "Se modificaron los datos correctamente...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public IEnumerable<PersonaModel> listarPersona()
        {
            try
            {
                return connection.Query<PersonaModel>($"SELECT * FROM persona order by id_persona asc");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
