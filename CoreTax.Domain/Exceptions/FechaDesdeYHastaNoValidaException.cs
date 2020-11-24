using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTax.Domain.Exceptions
{
    public class FechaDesdeYHastaNoValidaException : ApplicationException
    {
        public FechaDesdeYHastaNoValidaException() : base("Fecha desde y hasta son iguales")
        {

        }
    }
}
