using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTax.Domain.Entities.Impuestos
{
    public class Impuesto
    {
        public int Id { get; set; }
        public int CodigoImpuesto { get; set; }
        public int TipoCuenta { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Abbreviacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        public Impuesto(int codigoImpuesto, string nombre, string descripcion, string abbreviacion, DateTime fechaDesde , DateTime fechaHasta)
        {
            CodigoImpuesto = codigoImpuesto;
            Nombre = nombre;
            Descripcion = descripcion;
            Abbreviacion = abbreviacion;
            FechaCreacion = DateTime.Now;
            FechaCreacion = fechaDesde;
            FechaHasta = fechaHasta;
        }
        public bool IsActivo()
        {
            if (DateTime.Now.Date>= FechaDesde.Date && DateTime.Now<= FechaHasta.Date )
            {
                return true;
            }

            return false;
        }
   
        public bool IsFechaCreacionValida()
        {
            if (FechaCreacion.Date> DateTime.Now.Date)
            {
                return false;
            }

            return true;
        }

        public bool IsFechaDesdeYHastaIguales()
        {
            if (FechaCreacion.Date == FechaHasta.Date)
            {
                return true;
            }

            return false;
        }
       

    }
}
