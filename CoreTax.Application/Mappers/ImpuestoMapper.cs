using CoreTax.Application.ViewModels;
using CoreTax.Domain.Entities.Impuestos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTax.Application.Mappers
{
    public static class ImpuestoMapper
    {
        public static ImpuestoView toDto(this Impuesto impuesto)
        {
            return new ImpuestoView()
            {
                Abbreviacion = impuesto.Abbreviacion,
                Nombre = impuesto.Nombre,
                CodigoImpuesto = impuesto.CodigoImpuesto,
                FechaDesde = impuesto.FechaDesde,
                FechaHasta = impuesto.FechaHasta,
                TipoCuenta = impuesto.TipoCuenta,
                Id = impuesto.Id
            };
        }

        public static IList<ImpuestoView> toDto(this List<Impuesto> listImpuestos )
        {
            var listaImpuestosView = new List<ImpuestoView>();

            foreach (var impuesto in listImpuestos)
            {
                listaImpuestosView.Add(impuesto.toDto());
            }

            return listaImpuestosView;
        }
    }
}
