using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Embryo.Web.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Embryo.Data.Contexts;
using Embryo.Domain.Repositories;
using Embryo.Data.Repositories;
using Embryo.Data.Services;

namespace Embryo.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // Setup database connections
            var connection = @"Server=.\SQLEXPRESS;Database=Embryo;User Id=embryo-web;Password=embryo;";
            services.AddDbContext<SqlEfContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("Embryo.Data")));

            // Setup infrastructure
            services.AddTransient<IDbGuidGenerator, Base64GuidGenerator>();

            // Setup repositories
            services.AddTransient<IPostRepository, SqlPostRepository>();

            // App Settings configuration
            services.AddOptions();
            services.Configure<EmbryoSettings>(Configuration.GetSection("EmbryoSettings"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
