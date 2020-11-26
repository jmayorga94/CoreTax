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
        public Impuesto ObtenerDetalleImpuestoPorCodigo(int codigo)
        {
           var impuesto = _repository.ObtenerDetalleImpuestoPorCodigo(codigo);

            if ( impuesto ==null)
            {
                throw new ImpuestoNoEncontradoException();
            }

            return impuesto;
        }

        public Impuesto ObtenerDetalleImpuestoPorId(int id)
        {
            var impuesto = _repository.ObtenerDetalleImpuestoPorId(id);

            if (impuesto == null)
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

        public Impuesto Editar(int id, string nombre, int tipoCuenta, string abbreaviacion, DateTime fechaDesde, DateTime fechaHasta)
        {
            var impuestoAEditar = _repository.ObtenerDetalleImpuestoPorId(id);

            if (impuestoAEditar == null)
            {
                throw new ImpuestoNoEncontradoException();
            }

            impuestoAEditar.Abbreviacion = abbreaviacion;
            impuestoAEditar.Nombre = nombre;
            impuestoAEditar.FechaDesde = fechaDesde;
            impuestoAEditar.FechaHasta = fechaHasta;
            impuestoAEditar.TipoCuenta = tipoCuenta;


            if (impuestoAEditar.IsFechaDesdeYHastaIguales())
            {
                throw new FechaDesdeYHastaNoValidaException();
            }

            if (impuestoAEditar.IsFechaDesdeMayorAlAnioActual())
            {
                throw new FechaDesdeEsMayorAlAnioActualException();
            }


            return _repository.Editar(impuestoAEditar);
            
        }

        public Impuesto Insertar(int codigoImpuesto, string nombre, string descripcion, string abbreviacion, DateTime fechaDesde, DateTime fechaHasta)
        {
            var impuesto = new Impuesto(codigoImpuesto, nombre, descripcion, abbreviacion, fechaDesde, fechaHasta);

            if (impuesto.IsFechaDesdeYHastaIguales())
            {
                throw new FechaDesdeYHastaNoValidaException();
            }

            if (impuesto.IsFechaDesdeMayorAlAnioActual())
            {
                throw new FechaDesdeEsMayorAlAnioActualException();
            }

            return _repository.Insertar(impuesto);

        }

        public IEnumerable<Impuesto> ObtenerImpuestos()
        {
            return _repository.ObtenerImpuestos();
        }
    }
}
