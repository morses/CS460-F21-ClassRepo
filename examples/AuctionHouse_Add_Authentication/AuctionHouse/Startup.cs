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
using AuctionHouse.Areas.Identity.Data;

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
            services.AddRazorPages();
            services.AddDbContext<AuctionHouseDbContext>( options => 
                options.UseSqlServer(Configuration.GetConnectionString("AuctionHouseConnection"))
            );
            // Configure the built-in DI container to provide a BuyerRepository
            // when an IBuyerRepository is requested
            services.AddScoped( typeof(IRepository<>), typeof(Repository<>) );
            services.AddScoped<DbContext, AuctionHouseDbContext>();
            services.AddDbContext<AuctionHouseIdentityDbContext>( options => 
                options.UseSqlServer(Configuration.GetConnectionString("AuctionHouseIdentityDbContextConnection"))
            );
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

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
