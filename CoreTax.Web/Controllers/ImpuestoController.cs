using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CoreTax.Application.Messages;
using CoreTax.Application.Services;
using CoreTax.Domain.Exceptions;
using CoreTax.Domain.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CoreTax.Web.Controllers
{
    public class ImpuestoController : Controller
    {
        private readonly ImpuestosService _service;

        public ImpuestoController(ImpuestosService service)
        {
            _service = service;
        }
        public ViewResult Index()
        {
            ListarImpuestosResponse response = _service.ObtenerImpuestos();

            ViewData["success"] = response.Success;

            return View(response.ListImpuestos);
        }

        public ViewResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(CrearImpuestoRequest request)
        {
            if (ModelState.IsValid)
            {
                CrearImpuestosResponse response;

                response = _service.CrearImpuesto(request);

                TempData["success"] = response.Success;
                TempData["message"] = response.Message;

                if (!response.Success)
                {
                    ModelState.AddModelError("", response.Message);

                    return View(request);
                }

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(request);
            }

        }

        public ViewResult Editar(VerDetalleImpuestoRequest request)
        {
            var response = _service.ObtenerDetalleImpuestoPorId(request);

            TempData["success"] = response.Success;
            TempData["message"] = response.Message;

            return View(response.ImpuestoEditado);
        }

        [HttpPost]
        public IActionResult Editar(EditarImpuestoRequest request)
        {
            var response = _service.EditarImpuesto(request);

            TempData["success"] = response.Success;
            TempData["message"] = response.Message;

            if (!response.Success)
            {
                ModelState.AddModelError("", response.Message);

                return View(request);
            }

            return RedirectToAction(nameof(Index));

        }

 
    }
}