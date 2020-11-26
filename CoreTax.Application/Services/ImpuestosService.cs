using CoreTax.Application.Messages;
using CoreTax.Domain.Managers;
using CoreTax.Application.Mappers;
using System.Linq;
using System;

namespace CoreTax.Application.Services
{
    public class ImpuestosService
    {
        private readonly IImpuestosManager _impuestosManager;

        public ImpuestosService(IImpuestosManager ImpuestosManager)
        {
            _impuestosManager = ImpuestosManager;
        }


        public CrearImpuestosResponse CrearImpuesto(CrearImpuestoRequest request)
        {
            CrearImpuestosResponse response = new CrearImpuestosResponse();
            try
            {
                response.NuevoImpuesto = _impuestosManager.Insertar(request.CodigoImpuesto, request.Nombre, request.Descripcion, request.Abbreviacion, request.FechaDesde, request.FechaHasta).toDto();

                response.Success = true;
                response.Message = $"El impuesto {response.NuevoImpuesto.CodigoImpuesto}-{response.NuevoImpuesto.Nombre} ha sido guardado de manera exitosa";

            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;
            }
            
            return response;
        }

        public EditarImpuestoResponse EditarImpuesto(EditarImpuestoRequest request)
        {
            EditarImpuestoResponse response = new EditarImpuestoResponse();

            try
            {
                response.ImpuestoEditado = _impuestosManager.Editar(request.Id, request.Nombre, request.TipoCuenta, request.Abbreviacion, request.FechaDesde, request.FechaHasta).toEditarImpuestoDto();
                response.Success = true;
                response.Message = $"El impuesto {response.ImpuestoEditado.Nombre} ha sido editado exitosamente";
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;
            }
            

            return response;
        }

        public ListarImpuestosResponse ObtenerImpuestos()
        {
            ListarImpuestosResponse response = new ListarImpuestosResponse();

            try
            {
                response.ListImpuestos = _impuestosManager.ObtenerImpuestos().ToList().toDto();
                response.Success = true;
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;
            }
            

            return response;
        }       

        public EditarImpuestoResponse ObtenerDetalleImpuestoPorId(VerDetalleImpuestoRequest request)
        {
            EditarImpuestoResponse response = new EditarImpuestoResponse();

            try
            {
                response.ImpuestoEditado = _impuestosManager.ObtenerDetalleImpuestoPorId(request.Id).toEditarImpuestoDto();
                response.Success = true;
                
            }
            catch (Exception ex)
            {


                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
 
    }


}
