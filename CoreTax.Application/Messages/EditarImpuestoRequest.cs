using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTax.Application.Messages
{
    public class EditarImpuestoRequest
    {
        public int Id { get; set; }
        public int CodigoImpuesto { get; set; }
        public int TipoCuenta { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Abbreviacion { get; set; }
    }
}
