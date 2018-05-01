using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria_Back.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Cors;
namespace Livraria_Back
{
    public class Startup
    {
        public static IConfiguration Configuration { get;private set; }
        public Startup(IConfiguration configuration)
        {

            
            Configuration = configuration;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var webconfig = new WebConfig();
            
            Configuration.Bind("WebConfig", webconfig);
            services.AddSingleton(webconfig);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
            });
            services.AddMvc();
            
            //services.AddSingleton<IConfiguration>(Configuration);

            // services.AddSingleton(new Livraria_Back.Models.LivrariaContext());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("AllowAllHeaders");
            app.UseMvc();
        }
    }
}
