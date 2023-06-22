﻿using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class CuentaService
    {
        private CuentaRepository repositoryCuenta;

        public CuentaService(string connectionString)
        {
            this.repositoryCuenta = new CuentaRepository(connectionString);
        }

        public string insertarCuenta(CuentaModel cuenta)
        {
            return validarDatosCuenta(cuenta) ? repositoryCuenta.insertarCuenta(cuenta) : throw new Exception("Error en la validacion");
        }

        public string modificarCuenta(CuentaModel cuenta, int id)
        {
            if (repositoryCuenta.consultarCuenta(id) != null)
                return validarDatosCuenta(cuenta) ?
                    repositoryCuenta.modificarCuenta(cuenta, id) :
                    throw new Exception("Error en la validacion");
            else
                return "No se encontraron los datos de esta cuenta";
        }

        public string eliminarCuenta(int id)
        {
            return repositoryCuenta.eliminarCuenta(id);
        }

        public CuentaModel consultarCuenta(int id)
        {
            return repositoryCuenta.consultarCuenta(id);
        }

        public IEnumerable<CuentaModel> listarCuenta()
        {
            return repositoryCuenta.listarCuenta();
        }

        private bool validarDatosCuenta(CuentaModel cuenta)
        {
            //if (persona.Nombre.Trim().Length < 2)
            //{
            //    return false;
            //}

            return true;
        }

    }
}
