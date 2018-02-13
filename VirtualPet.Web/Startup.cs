using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using VirtualPet.Models;
using VirtualPet.Repositories;
using VirtualPet.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace VirtualPet.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private Animals SeedData()
        {
            return new Animals
            {
                new Cat
                {
                    Owner = "jayconnerghost@gmail.com",
                    Name = "fred",
                    Type = AnimalTypes.Cat
                },
                new Cat
                {
                    Owner="jayconnerghost@gmail.com",
                    Name="silky",
                    Type=AnimalTypes.Cat
                }

            };
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IAnimals>(SeedData());
            services.AddSingleton<IAnimalRepository, InMemoryAnimalRepository>();
            services.AddTransient<IAnimalFindService, AnimalFindService>();
            services.AddTransient<IAnimalPettingService, AnimalPettingService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "VirtualPet API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "VirtualPet API V1");
            });

            app.UseMvc();
        }
    }
}
