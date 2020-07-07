using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Catalyna.Core.Interfaces;
using Catalyna.Core.Services;
using Catalyna.Infraestructure.Data;
using Catalyna.Infraestructure.Filters;
using Catalyna.Infraestructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
            //services.AddControllers();

            //Agregando AutoMapper a nuestro servicio
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Esta es la modificacion para evitar errores de referencia circular.
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            })
            .ConfigureApiBehaviorOptions(options => {
                //options.SuppressModelStateInvalidFilter = true; //Para suprimir las validaciones de modelo, en el caso necesites usarlo
            
            });

            //Registrar la Base de datos a acceder
            services.AddDbContext<CatalynaMediaContext>(options =>
                   options.UseSqlServer(Configuration.GetConnectionString("CatalynaDB"))
            );

            //Resolver dependencias Aqui :)
            services.AddTransient<IArticleRepository, ArticleRepository>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            //Cada vez que en el programa se haga uso de esta abstraccion yo le voy a entregar
            //a esa clase una instancia de esa implementacion

            services.AddMvc(options => 
            {
                options.Filters.Add<ValidationFilter>();

            }).AddFluentValidation(options =>    //Registrar Fluent Validation en StartUP
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
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
