using CoreTax.Domain.Entities.Impuestos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTax.Domain.Repositories
{
    public interface IImpuestosRepository
    {
        Impuesto Insertar(Impuesto impuesto);
        IEnumerable<Impuesto> ObtenerImpuestos();
        Impuesto Editar(Impuesto impuesto);
        void DarDeBajaImpuesto(int id);
        void Guardar();
        Impuesto ObtenerImpuestoPorCodigo(int codigo);
        Impuesto ObtenerImpuestoPorId(int id);
    }
}
