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

        public Impuesto Editar(int id, Impuesto impuesto)
        {
            var impuestoAEditar = _repository.ObtenerImpuestoPorId(id);

            if (impuestoAEditar == null)
            {
                throw new ImpuestoNoEncontradoException();
            }

            if (!impuesto.IsFechaCreacionValida())
            {
                throw new FechaCreacionNoValidaException();
            }

            if (!impuesto.IsFechaDesdeYHastaIguales())
            {
                throw new FechaDesdeYHastaNoValidaException();
            }

            impuestoAEditar.Abbreviacion = impuesto.Abbreviacion;
            impuestoAEditar.Nombre = impuesto.Nombre;
            impuestoAEditar.TipoCuenta = impuesto.TipoCuenta;
            impuestoAEditar.CodigoImpuesto = impuesto.CodigoImpuesto;

            return _repository.Editar(impuestoAEditar);
            
        }

        public Impuesto Insertar(Impuesto impuesto)
        {
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
