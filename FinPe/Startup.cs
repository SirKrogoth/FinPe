using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinPe.Model.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace FinPe
{
    public class Startup
    {
        private IConfiguration _configuration { get;  }
        private IHostingEnvironment _environment { get; }
        private readonly ILogger _logger;

        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var stringConexao = _configuration["MysqlConnection:MysqlConnectionString"];

            services.AddDbContext<MysqlContext>(options => options.UseMySql(stringConexao));
            
            //SWAGGER
            services.AddSwaggerGen(c =>
            {
                //v1 é a versão utilizada
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "FinPe - Sistema de Finanças Pessoais" +
                        "V1"
                    });
            });

            //Serviço de versionamento
            services.AddApiVersioning();

            ExecuteMigrations(stringConexao);

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(_configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //Abrindo swagger como página inicial
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "{controller=values}/{id?}");
            });
        }

        private void ExecuteMigrations(string stringConexao)
        {
            if(_environment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(stringConexao);

                    var evolve = new Evolve.Evolve(evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "db/migrations" },
                        IsEraseDisabled = true,
                    };

                    evolve.Migrate();
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Database Migrations failed. ", ex);
                    throw;
                }                
            }
        }
    }
}
