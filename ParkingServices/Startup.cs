using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ParkingServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingServices
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
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            services.AddAuthentication(IISDefaults.AuthenticationScheme);
           

            if (env == "Development")
            {
                services.AddDbContext<ParkingContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DbConnection"))
             );
                services.AddAuthorization(options =>
                {
                    //options.AddPolicy("AllowedRolesOnly", policy => policy.RequireRole(Configuration["SecuritySettings:ADGroup"]));
                    options.AddPolicy("AllowedRolesOnly", policy => policy.RequireRole(Configuration["SecuritySettings:ADGroup2"]));
                });
            }

            if (env == "Production")
            {
                services.AddDbContext<ParkingContext>(options =>
                 options.UseSqlServer(Configuration.GetConnectionString("DbConnectionProd"))
             );
                services.AddAuthorization(options =>
                {
       
                    options.AddPolicy("AllowedRolesOnly", policy => policy.RequireRole(Configuration["SecuritySettings:ADGroup"]));
                    //options.AddPolicy("AllowedRolesOnly", policy => policy.RequireRole(Configuration["SecuritySettings:ADGroup2"]));
                });

            }
            services.AddControllersWithViews();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Complaint}/{action=Index}/{id?}");
            });
        }
    }
}
