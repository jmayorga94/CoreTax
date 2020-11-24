using CoreTax.Application.Services;
using CoreTax.Domain.Managers;
using CoreTax.Domain.Repositories;
using CoreTax.Infrastructure.Data;
using CoreTax.Infrastructure.Repositories.Impuestos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CoreTax.Infrastructure.Data.Impuestos;
namespace CoreTax.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddTransient<IImpuestosManager, ImpuestosManager>();
            services.AddTransient<IImpuestosRepository, ImpuestosRepositoryImpl>();
            services.AddScoped<ImpuestosService>();
            services.AddDbContext<CoreTaxDbContext>(options => options.UseSqlServer(Configuration["Data:ConnectionString:CoreTaxDb"],b=> b.MigrationsAssembly("CoreTax.Web")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.EnsurePopulated();
        }
    }
}
