using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement
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

            services.AddDbContextPool<AppDbContext>(
           options => options.UseSqlServer(
               Configuration.GetConnectionString("EmployeeDBConnection")));

            //this method can be used to change 
            //services.Configure<IdentityOptions>(options =>
            //{

            //    options.Password.RequireDigit

            //});

            services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddScoped<IEmployeeRepository, SQLRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //}

            app.UseStaticFiles();
            app.UseAuthentication();

            //app.UseMvc(c=>
            //{
            //    c.MapRoute("default", "{controller}/{action}/{id}");
            //});
            app.UseMvc();
  

            //app.Run(async (context) =>
            //{
            //    throw new Exception("fuck");

            //    await context.Response.WriteAsync("hello World");

            //});
            //app.UseCookiePolicy();
            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW1: Incoming Request");
            //    await next();
            //    logger.LogInformation("MW1: Outgoing Response");
            //});
            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW2: Incoming Request");
            //    await next();
            //    logger.LogInformation("MW2: Outgoing Response");
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("MW3: Request handled and response produced");
            //    logger.LogInformation("MW3: Request handled and response produced");
            //});

        }
    }
}
