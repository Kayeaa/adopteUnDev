using BLLObject = BLL.Entities;
using DALObject = DAL.Entities;
using BLLService = BLL.Services;
using DALService = DAL.Services;
using Common.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adopteUnDev
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

            #region Client
            services.AddControllersWithViews();
            services.AddScoped<IClientRepository<BLLObject.Client, int>, BLLService.ClientService>();
            services.AddScoped<IClientRepository<DALObject.Client, int>, DALService.ClientService>();
            #endregion

            #region Developer
            //services.AddControllersWithViews();
            services.AddScoped<IDeveloperRepository<BLLObject.Developer, int>, BLLService.DevService>();
            services.AddScoped<IDeveloperRepository<DALObject.Developer, int>, DALService.DevService>();
            #endregion



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
        }
    }
}
