using CoreTax.Application.Messages;
using CoreTax.Domain.Managers;
using CoreTax.Application.Mappers;
using System.Linq;

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

            response.NuevoImpuesto = _impuestosManager.Insertar(request.CodigoImpuesto,request.Nombre,request.Descripcion,request.Abbreviacion,request.FechaDesde,request.FechaHasta).toDto();

            return response;
        }

        public EditarImpuestoResponse EditarImpuesto(EditarImpuestoRequest request)
        {
            EditarImpuestoResponse response = new EditarImpuestoResponse();

            response.ImpuestoEditado = _impuestosManager.Editar(request.Id, request.CodigoImpuesto, request.Nombre, request.Descripcion, request.Abbreviacion).toDto();

            return response;
        }

        public ListarImpuestosResponse ObtenerImpuestos()
        {
            ListarImpuestosResponse response = new ListarImpuestosResponse();

            response.ListImpuestos = _impuestosManager.ObtenerImpuestos().ToList().toDto();

            return response;
        }       

    }
}
