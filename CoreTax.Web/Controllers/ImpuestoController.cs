using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CoreTax.Application.Messages;
using CoreTax.Application.Services;
using CoreTax.Domain.Managers;
using Microsoft.AspNetCore.Mvc;

namespace CoreTax.Web.Controllers
{
    public class ImpuestoController : Controller
    {
        private readonly ImpuestosService _service;

        public ImpuestoController(ImpuestosService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            ListarImpuestosResponse response = new ListarImpuestosResponse();
            try
            {
                 response = _service.ObtenerImpuestos();

                if (response.ListImpuestos != null)
                {
                    response.Success = true;

                }
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;
            }
            
            
            return View(response.ListImpuestos);
        }
    }
}