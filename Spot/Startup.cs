using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Spot.StatsManagement.Infrastructure;

namespace Spot
{
    public class Startup
    {
        public static IConfiguration Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appSettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter()))
                .AddJsonOptions(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            var connectionString = Configuration["connectionStrings:DWAPICentralConnection"];
            services.AddDbContext<SpotContext>(o => o.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }

            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404 &&
                    !Path.HasExtension(context.Request.Path.Value) &&
                    !context.Request.Path.Value.StartsWith("/api/"))
                {
                    context.Request.Path = "/index.html";
                    await next();
                }
            });

            app.UseMvcWithDefaultRoute();
            app.UseDefaultFiles();
            app.UseStaticFiles();

          
            Log.Debug(@"---------------------------------------------------------------------------------------------------");
            Log.Debug
            (@"

                                       _____ _____   ____ _______ 
                                      / ____|  __ \ / __ \__   __|
                                     | (___ | |__) | |  | | | |   
                                      \___ \|  ___/| |  | | | |   
                                      ____) | |    | |__| | | |   
                                     |_____/|_|     \____/  |_|   
                              
                              


            ");
            Log.Debug(@"---------------------------------------------------------------------------------------------------");
            Log.Debug("Spot started !");
        }
    }
}
