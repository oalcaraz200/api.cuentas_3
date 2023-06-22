using Dapper;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class CuentaRepository
    {

        private string _connectionString;
        private Npgsql.NpgsqlConnection connection;
        public CuentaRepository(string connectionString)
        {
            _connectionString = connectionString;
            connection = new Npgsql.NpgsqlConnection(_connectionString);
        }

        public CuentaModel consultarCuenta(int id)
        {
            try
            {
                return connection.QueryFirst<CuentaModel>($"SELECT * FROM cuenta WHERE id = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string insertarCuenta(CuentaModel cuenta)
        {
            try
            {
                connection.Execute("insert into cuenta (id_persona, nombre_cuenta, numero_cuenta, saldo, limite_saldo, limite_transferencia, estado) " +
                    " values(@id_persona, @nombre_cuenta, @numero_cuenta, @saldo, @limite_saldo, @limite_transferencia, @estado)", cuenta
                    );
                return "Se inserto correctamente...";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        

        public string eliminarCuenta(int id)
        {
            try
            {
                connection.Execute($" DELETE FROM cuenta WHERE id = {id}");
                return "Se eliminó correctamente el registro...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public string modificarCuenta(CuentaModel cuenta, int id)
        {
            try
            {

                connection.Execute($"UPDATE cuenta SET " +
                    "id_persona = @id_persona, " +
                    "nombre_cuenta = @nombre_cuenta, " +
                    "numero_cuenta = @numero_cuenta, " +
                    "saldo = @saldo, " +
                    "limite_saldo = @limite_saldo, " +
                    "limite_transferencia = @limite_transferencia, " +
                     "estado = @estado " +
                    $"WHERE id= {id}", cuenta);
                return "Se modificaron los datos correctamente...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public IEnumerable<CuentaModel> listarCuenta()
        {
            try
            {
                return connection.Query<CuentaModel>($"SELECT * FROM cuenta order by id asc");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
