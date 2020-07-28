using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using solid.Models;
using solid.Services;
using solid.Common;
using solid.Repositories;
using solid.Services.SingleResponsabilityPrinciple;
using solid.Services.OpenClosePrinciple;

namespace solid
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
            services.AddControllers();
            AddSolidServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private ILoggerFactory CreateLoggerFactory(IServiceProvider provider)
        {
            var loggerFactory = provider.GetService<ILoggerFactory>();
            return loggerFactory;
        }

        private void AddSolidServices(IServiceCollection services)
        {
            ILoggerFactory loggerFactory = CreateLoggerFactory(services.BuildServiceProvider());
            IConnection connectionManagerInstance = new ConnectionManager();
            IOpenClose<Entity> openCloseRectangleInstance = new Rectangle();

            services.AddSingleton<ISingleResponsability<User>>(new SingleResponsabilityPrinciple(loggerFactory, connectionManagerInstance));

            Entity entity = new Entity(45.9, 78.9);

            services.AddSingleton(new OpenClosePrinciple(loggerFactory, openCloseRectangleInstance, entity));

            services.AddSingleton(new LiskovSubstitutionPrinciple(loggerFactoryy));
        }
    }
}
