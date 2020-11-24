using CoreTax.Domain.Entities.Impuestos;
using CoreTax.Domain.Repositories;
using CoreTax.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreTax.Infrastructure.Repositories.Impuestos
{
    public class ImpuestosRepositoryImpl : IImpuestosRepository
    {
        private readonly CoreTaxDbContext _context;
        public ImpuestosRepositoryImpl(CoreTaxDbContext context)
        {
            _context = context;
        }
        public Impuesto ObtenerImpuestoPorCodigo(int codigo)
        {
            return _context.Impuestos.FirstOrDefault(x => x.CodigoImpuesto == codigo);
        }

        public void DarDeBajaImpuesto(int id)
        {
            var impuestoADarDeBaja = _context.Impuestos.FirstOrDefault(x => x.Id == id);

            _context.Impuestos.Remove(impuestoADarDeBaja);

            Guardar();
        }

        public Impuesto Editar( Impuesto impuesto)
        {
            _context.Impuestos.Add(impuesto);

            Guardar();

            return impuesto;
        }

        public void Guardar()
        {
            _context.SaveChanges();
        }

        public Impuesto Insertar(Impuesto impuesto)
        {
            _context.Impuestos.Add(impuesto);

            Guardar();

            return impuesto;
        }

        public Impuesto ObtenerImpuestoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Impuesto> ObtenerImpuestos()
        {
            return _context.Impuestos.ToList();
        }
    }
}
