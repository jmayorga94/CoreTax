using CoreTax.Domain.Entities.Impuestos;
using System.Collections.Generic;

namespace CoreTax.Domain.Managers
{
    public interface IImpuestosManager
    {
        Impuesto Insertar(Impuesto impuesto);
        IEnumerable<Impuesto> ObtenerImpuestos();
        Impuesto Editar(int id, Impuesto impuesto);
        void DarDeBajaImpuesto(int id);
        Impuesto BuscarImpuestoPorCodigo(int codigo);
    }
}
