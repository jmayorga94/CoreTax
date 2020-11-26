using CoreTax.Domain.Entities.Impuestos;
using System;
using System.Collections.Generic;

namespace CoreTax.Domain.Managers
{
    public interface IImpuestosManager
    {
        Impuesto Insertar(int codigoImpuesto, string nombre, string descripcion, string abbreviacion, DateTime fechaDesde, DateTime fechaHasta);
        IEnumerable<Impuesto> ObtenerImpuestos();
        Impuesto Editar(int id, string nombre, int tipoCuenta, string abbreaviacion, DateTime fechaDesde, DateTime fechaHasta);
        void DarDeBajaImpuesto(int id);
        Impuesto ObtenerDetalleImpuestoPorCodigo(int codigo);
        Impuesto ObtenerDetalleImpuestoPorId(int id);
    }
}
