using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTax.Application.ViewModels
{
    public class EditarImpuestoView
    {
        public int Id { get; set; }
        public int TipoCuenta { get; set; }
        public string Nombre { get; set; }
        public string Abbreviacion { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
    }
}
