using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTax.Domain.Exceptions
{
    public class FechaDesdeEsMayorAlAnioActualException : ApplicationException
    {
        public FechaDesdeEsMayorAlAnioActualException() : base("Fecha Desde es mayor al año actual")
        {

        }
    }
}
