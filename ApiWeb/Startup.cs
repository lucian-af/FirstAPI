using System;
using ApiWeb.Data;
using ApiWeb.Repositorios.Produto;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ApiWeb
{
    public class Startup
    {
        /// <summary>
        /// Nesse método que adicionamos os nossos middlewares
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddResponseCompression();

            // Scooped, verifica na memoria se existe o objeto, se não existir ele cria
            services.AddScoped<StoreDataContext, StoreDataContext>();

            // Transient, toda vez que solicitar um objeto ele instancia um novo objeto
            services.AddTransient<ProdutoRepositorio, ProdutoRepositorio>();
            services.AddTransient<CategoriaRepositorio, CategoriaRepositorio>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Api Web",
                        Version = "v1",
                        Description = "Minha primeira api criada e documentada"
                    });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Esse bloco é útil para ambiente de desenvolvimento, tratamento de erros, etc
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseResponseCompression();

            app.UseSwagger(); // documentação no formato json
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Web - v1");
            });
        }
    }
}
