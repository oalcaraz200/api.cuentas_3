using Dapper;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class OperacionesRepository
    {
        private string _connectionString;
        private Npgsql.NpgsqlConnection connection;
        public OperacionesRepository(string connectionString)
        {
            _connectionString = connectionString;
            connection = new Npgsql.NpgsqlConnection(_connectionString);
        }


        public CuentaModel consultarCuenta(string numeroCuenta)
        {
            try
            {
                return connection.QueryFirst<CuentaModel>($"SELECT * FROM cuenta WHERE id = {numeroCuenta} ");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                System.Console.WriteLine(ex.Message);
            }
        }

        public string modificarCuenta(CuentaModel cuenta)
        {
            try
            {
                connection.Execute($"UPDATE cuenta SET " +
                    "idPersona = @idPersona, " +
                    "nombreCuenta = @nombreCuenta, " +
                    "numeroCuenta = @numeroCuenta , " +
                    "saldo = @saldo, " +
                    "limite = @limite, " +
                    "moneda = @moneda, " +
                    "estado = @estado " +
                    $"WHERE id = {cuenta.id}", cuenta);
                return "Se modificaron los datos correctamente...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


       



    }
}
