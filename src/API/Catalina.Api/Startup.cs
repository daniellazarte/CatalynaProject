using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalyna.Core.Interfaces;
using Catalyna.Infraestructure.Data;
using Catalyna.Infraestructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Catalina.Api
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
            //Registrar la Base de datos a acceder
            services.AddDbContext<CatalynaMediaContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("CatalynaDB"))
            );

            //Resolver dependencias Aqui :)
            services.AddTransient<IArticleRepository, ArticleRepository>();
            //Cada vez que en el programa se haga uso de esta abstraccion yo le voy a entregar
            //a esa clase una instancia de esa implementacion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
