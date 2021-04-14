using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using EgyptExcavation.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EgyptExcavation.Models;

namespace EgyptExcavation
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
            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlite(
            //        Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<egyptexcavationContext>(options =>
                options.UseSqlServer(Configuration["ConnectionStrings:EgyptExcavationConnection"]));

            //services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
                //sets up different end points so that the URL looks nice
                //Here are the routes, but they were messing up the pagination and we ran out of time
                ////age routes
                //endpoints.MapControllerRoute("agepage",
                //    "age/{age}/{pagenum:int}",
                //    new { Controller = "Home", action = "BurialList" });

                ////gender routes
                //endpoints.MapControllerRoute("genderpage",
                //    "gender/{gender}/{pagenum:int}",
                //    new { Controller = "Home", action = "BurialList" });

                ////headdirection routes
                //endpoints.MapControllerRoute("headdirectionpage",
                //    "headdirection/{headdirection}/{pagenum:int}",
                //    new { Controller = "Home", action = "BurialList" });

                ////haircolor routes
                //endpoints.MapControllerRoute("haircolorpage",
                //    "haircolor/{haircolor}/{pagenum:int}",
                //    new { Controller = "Home", action = "BurialList" });

                ////artifacts routes
                //endpoints.MapControllerRoute("artifactspage",
                //    "artifacts/{artifacts}/{pagenum:int}",
                //    new { Controller = "Home", action = "BurialList" });

                //endpoints.MapControllerRoute("age",
                //    "age/{age}",
                //    new { Controller = "Home", action = "BurialList", pagenum = 1 });

                //endpoints.MapControllerRoute("gender",
                //    "gender/{gender}",
                //    new { Controller = "Home", action = "BurialList", pagenum = 1 });

                //endpoints.MapControllerRoute("headdirection",
                //    "headdirection/{headdirection}",
                //    new { Controller = "Home", action = "BurialList", pagenum = 1 });

                //endpoints.MapControllerRoute("haircolor",
                //    "haircolor/{haircolor}",
                //    new { Controller = "Home", action = "BurialList", pagenum = 1 });

                //endpoints.MapControllerRoute("artifacts",
                //    "artifacts/{artifacts}",
                //    new { Controller = "Home", action = "BurialList", pagenum = 1 });

                //endpoints.MapControllerRoute("page",
                //    "page/{pagenum:int}",
                //    new { Controller = "Home", action = "BurialList" });

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
