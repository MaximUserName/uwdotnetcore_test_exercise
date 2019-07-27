using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acro.BusinessLogic.Implementations;
using Acro.BusinessLogic.Interfaces;
using Acro.Common;
using Acro.Data.Implementations;
using Acro.Data.Interfaces;
using Acro.Data.StoredProcs;
using Acro.WebApi.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Acro.WebApi
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
	        services.AddCors();
            services.AddMvcFiltersAndOptions()
	            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSwaggerGen(c =>
            {
	            c.SwaggerDoc("v1", new Info { Title = "ACRO API (DEV)", Version = "v1" });
            });

            services.AddScoped<IProductBusinessLogic, ProductBusinessLogic>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<StoredProcWrapper>();

            services.AddSingleton<DbSettings>(new DbSettings()
            {
				ConnectionString = this.Configuration.GetConnectionString("DefaultConnection")
			});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
	        app.UseStaticFiles();
	        // global cors policy
	        app.UseCors(x => x
		        .AllowAnyOrigin()
		        .AllowAnyMethod()
		        .AllowAnyHeader());
	        app.UseSwagger();
	        app.UseMvc();

	        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
	        // specifying the Swagger JSON endpoint.
	        app.UseSwaggerUI(c =>
	        {
		        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ACRO API V1");
		        c.RoutePrefix = string.Empty;
	        });
		}
    }
}
