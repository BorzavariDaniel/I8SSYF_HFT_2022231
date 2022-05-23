using Castle.Core.Configuration;
using I8SSYF_HFT_2021221.Data;
using I8SSYF_HFT_2021221.Logic;
using I8SSYF_HFT_2021221.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace I8SSYF_HFT_2021221.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

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

            services.AddSwaggerGen(x => x.SwaggerDoc("v1", new OpenApiInfo { Title = "I8SSYF_HFT_2021221.Endpoint", Version = "v1" }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/vi/swagger.json", "I8SSYF_HFT_2021221.Endpoint v1"));
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
