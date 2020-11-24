using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTax.Domain.Exceptions
{
    public class FechaCreacionNoValidaException : ApplicationException
    {
        public FechaCreacionNoValidaException():base("Fecha de creacion no valida")
        {

        }
    }
}
