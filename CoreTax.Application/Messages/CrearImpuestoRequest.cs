using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoreTax.Application.Messages
{
    public class CrearImpuestoRequest
    {
        [Required(ErrorMessage ="Ingrese el codigo de impuesto")]

        public int CodigoImpuesto { get; set; }

        [Required(ErrorMessage = "Ingrese el tipo de cuenta")]
        public int TipoCuenta { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingrese una descripcion")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Ingrese una abbreviacion")]
        public string Abbreviacion { get; set; }
        [Required(ErrorMessage = "Ingrese una fecha desde")]
        public DateTime FechaDesde { get; set; }
        [Required(ErrorMessage = "Ingrese una fecha hasta")]
        public DateTime FechaHasta { get; set; }

    }
}
