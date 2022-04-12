using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SimpleWebApplication.ApplicationServices;
using SImpleWebApplication.Infrastructure;

namespace SimpleWebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)//настройка DI контейнера
        {
            services.AddControllers();//подкл. контроллеры (автогенерация)
            services.AddHttpClient();//подкл. клиент
            services.AddScoped<SwapiApplicationService>();//в Di контейнер доб. сервис, чтобы можно было inject в peopleController
            services.AddHttpClient<ISwapiPeopleHttpClient, SwapiPeopleHttpClient>(c =>
            {
                c.BaseAddress = new Uri($"{Configuration["SwapiBaseAddress"]}/api/people/");
            });
            services.AddHttpClient<ISwapiHomeworldHttpClient, SwapiHomeworldHttpClient>(c =>
            {
                c.BaseAddress = new Uri($"{Configuration["SwapiBaseAddress"]}/api/planets/");
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "SimpleWebApplication", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SimpleWebApplication v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}