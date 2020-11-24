using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTax.Application.Messages
{
    public class CrearImpuestoRequest
    {
        public int CodigoImpuesto { get; set; }
        public int TipoCuenta { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Abbreviacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

    }
}
