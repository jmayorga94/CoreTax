using CoreTax.Domain.Entities.Impuestos;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreTax.Infrastructure.Data.Impuestos
{
    public static class SeedImpuestoData
    {
        public static void EnsurePopulated( this IApplicationBuilder app)
        {
            CoreTaxDbContext context = app.ApplicationServices.GetRequiredService<CoreTaxDbContext>();
            context.Database.EnsureCreated();

            var impuesto = context.Impuestos.FirstOrDefault(x => x.Id == 1);
           
            if (impuesto == null)
            {
                List<Impuesto> impuestosList = new List<Impuesto>();

                impuestosList.Add(new Impuesto()
                {
                    Nombre = "Impuesto 101",
                    Descripcion = "Impuesto sobre la renta",
                    FechaCreacion = DateTime.Now,
                    FechaHasta = DateTime.Now.AddDays(5),
                    CodigoImpuesto = 101,
                    TipoCuenta = 1,
                    Abbreviacion = "ISR-101",
                    FechaDesde = DateTime.Now
                }) ;

                if (context.Impuestos.Count()==0)
                {

                    context.Impuestos.AddRange(impuestosList);
                
                }
                context.SaveChanges();
            }
        }
    }
}
