using I8SSYF_HFT_2021221.Data;
using I8SSYF_HFT_2021221.Logic;
using I8SSYF_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace I8SSYF_HFT_2021221.Endpoint
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<IEngineLogic, EngineLogic>();
            services.AddTransient<IModelLogic, ModelLogic>();
            //services.AddTransient<,>();

            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IModelRepository, ModelRepository>();
            services.AddTransient<IEngineRepository, EngineRepository>();

            services.AddTransient<CarDbContext, CarDbContext>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
