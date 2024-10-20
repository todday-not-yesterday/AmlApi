using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmlApi.DataAccess;
using AmlApi.IoC;
using Microsoft.EntityFrameworkCore;

namespace AmlApi
{
	using System.IO;
	using System.Reflection;
	using Autofac;
	using AmlApi.IoC;

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
			
			services.AddSwaggerGen();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = this.GetType().Assembly.GetName().Name, 
					Description = "Advanced Media Library",
					Version = "v1"
				});
			});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.UseCors(builder => builder
				.AllowAnyHeader()
				.AllowAnyMethod()
				.SetIsOriginAllowed((host) => true)
				.AllowCredentials()
			);
			
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			
			app.UseSwagger();
			
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", this.GetType().Assembly.GetName().Name);
				c.RoutePrefix = string.Empty;
			});

			//app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		public void ConfigureContainer(ContainerBuilder builder)
		{
			builder.RegisterModule(new AmlModule(this.Configuration));
		}
	}
}
