using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTax.Domain.Exceptions
{
    public class ImpuestoNoEncontradoException : ApplicationException
    {
        public ImpuestoNoEncontradoException() :base("No se encontro el impuesto")
        {

        }
    }
}
