using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AuctionHouse.Models;
using Microsoft.EntityFrameworkCore;
using AuctionHouse.DAL.Abstract;
using AuctionHouse.DAL.Concrete;

namespace AuctionHouse
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
            services.AddControllersWithViews();
            services.AddDbContext<AuctionHouseDbContext>(options =>
            {
                // This one loads from your appsettings.json, or from "Connection Strings" section in Configuration on Azure 
                //options.UseSqlServer(Configuration.GetConnectionString("AuctionHouseConnection"));

                // This one works with dotnet user-secrets, or the "Application Settings" secton in Configuration on Azure
                // ---> So if you want it to work both locally and on Azure without editing the code here to switch between them:
                // ---> store your connection string in user-secrets and NOT in appsettings
                options.UseSqlServer(Configuration["ConnectionStrings:AuctionHouseConnection"]);
            }
               
            );
            // Configure the built-in DI container to provide a BuyerRepository
            // when an IBuyerRepository is requested
            services.AddScoped( typeof(IRepository<>), typeof(Repository<>) );
            services.AddScoped<DbContext, AuctionHouseDbContext>();
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
