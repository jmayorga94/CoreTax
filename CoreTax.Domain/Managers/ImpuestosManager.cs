using CoreTax.Domain.Entities.Impuestos;
using CoreTax.Domain.Exceptions;
using CoreTax.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTax.Domain.Managers
{
    public class ImpuestosManager : IImpuestosManager
    {
        private readonly IImpuestosRepository _repository;
        public ImpuestosManager(IImpuestosRepository repository)
        {
            _repository = repository;
        }
        public Impuesto BuscarImpuestoPorCodigo(int codigo)
        {
           var impuesto = _repository.ObtenerImpuestoPorCodigo(codigo);

            if ( impuesto ==null)
            {
                throw new ImpuestoNoEncontradoException();
            }

            return impuesto;
        }

        public void DarDeBajaImpuesto(int id)
        {
             //Todo incorporar logica para dar de baja  por fecha desde y hasta

            _repository.DarDeBajaImpuesto(id);
        }

        public Impuesto Editar(int id, int codigoImpuesto, string nombre, string descripcion, string abbreviacion)
        {
            var impuestoAEditar = _repository.ObtenerImpuestoPorId(id);

            if (impuestoAEditar == null)
            {
                throw new ImpuestoNoEncontradoException();
            }

            impuestoAEditar.Abbreviacion = abbreviacion;
            impuestoAEditar.Nombre = nombre;
            impuestoAEditar.CodigoImpuesto =codigoImpuesto;
           

            return _repository.Editar(impuestoAEditar);
            
        }

        public Impuesto Insertar(int codigoImpuesto, string nombre, string descripcion, string abbreviacion, DateTime fechaDesde, DateTime fechaHasta)
        {
            var impuesto = new Impuesto(codigoImpuesto, nombre, descripcion, abbreviacion, fechaDesde, fechaHasta);

            if (!impuesto.IsFechaCreacionValida())
            {
                throw new FechaCreacionNoValidaException();
            }

            if (!impuesto.IsFechaDesdeYHastaIguales())
            {
                throw new FechaDesdeYHastaNoValidaException();
            }

            return _repository.Insertar(impuesto);

        }

        public IEnumerable<Impuesto> ObtenerImpuestos()
        {
            return _repository.ObtenerImpuestos();
        }
    }
}
