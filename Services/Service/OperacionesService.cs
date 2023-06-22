using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Repository;
using System;
using System.Reflection;

namespace Services.Service
{
    public class OperacionesService
    {
        private CuentaRepository repositoryCuenta;

        public OperacionesService(CuentaRepository repositoryCuenta)
        {
            this.repositoryCuenta = repositoryCuenta;
        }

        public string Transferir(int idCuentaOriginal, int idCuentaDestino, int monto)
        {
            var cuentaOr = repositoryCuenta.consultarCuenta(idCuentaOriginal);
            var cuentaDes = repositoryCuenta.consultarCuenta(idCuentaDestino);

            if (monto < 0)
            {
                throw new ArgumentException("No debe ser un monto negativo.");
            }

            if (cuentaOr.id == cuentaDes.id)
            {
                throw new ArgumentException("No se puede transferir a la misma cuenta.");
            }

            if (cuentaOr.limite_transferencia < monto || cuentaDes.limite_saldo < (cuentaDes.saldo + monto))
            {
                throw new ArgumentException("El monto de transferencia es mayor al límite.");
            }

            if (cuentaOr.estado == "inactivo" || cuentaDes.estado == "inactivo")
            {
                throw new ArgumentException("Cuenta inactiva o deshabilitada.");
            }

            if (cuentaOr.saldo < monto)
            {
                throw new ArgumentException("Saldo insuficiente.");
            }

            cuentaOr.saldo -= monto;
            cuentaDes.saldo += monto;

            repositoryCuenta.modificarCuenta(cuentaOr, idCuentaOriginal);
            repositoryCuenta.modificarCuenta(cuentaDes, idCuentaDestino);
            return "Transferencia realizada con éxito.";
        }

        public string Depositar(int idCuentaOriginal, int monto)
        {
            var cuentaOri = repositoryCuenta.consultarCuenta(idCuentaOriginal);

            if (cuentaOri.estado == "inactivo")
            {
                throw new ArgumentException("Cuenta inactiva o inhabilitada.");
            }

            if (cuentaOri.limite_saldo < (cuentaOri.saldo + monto))
            {
                throw new ArgumentException("Límite de saldo superado.");
            }

            cuentaOri.saldo += monto;

            repositoryCuenta.modificarCuenta(cuentaOri, idCuentaOriginal);

            return "Depósito realizado con éxito.";
        }
        public string Extraer(int monto, int idCuentaOriginal)
        {
            var cuentaOri = repositoryCuenta.consultarCuenta(idCuentaOriginal);

            if (cuentaOri.estado == "inactivo")
            {
                throw new ArgumentException("Cuenta inactiva o inhabilitada.");
            }
            if (cuentaOri.saldo < monto)
            {
                throw new InvalidOperationException("Saldo insuficiente");
            }

            cuentaOri.saldo -= monto;
            repositoryCuenta.modificarCuenta(cuentaOri, idCuentaOriginal);

            return "Extracción exitosa.";

        }

        public string Bloquear(int idCuentaOriginal)
        {
            var cuentaOri = repositoryCuenta.consultarCuenta(idCuentaOriginal);

            if (cuentaOri == null)
            {
                throw new ArgumentException("Cuenta inválida.");
            }

            cuentaOri.estado = "inactivo";

            repositoryCuenta.modificarCuenta(cuentaOri, idCuentaOriginal);

            return "Cuenta bloqueada con éxito.";
        }

        public string Imprimir(int idCuentaOriginal)
        {
            var cuentaOri = repositoryCuenta.consultarCuenta(idCuentaOriginal);

            return "Tu saldo actual es: " + cuentaOri.saldo;
        }
    }
}

