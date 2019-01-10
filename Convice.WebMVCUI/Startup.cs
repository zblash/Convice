using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Convice.Business.Abstract;
using Convice.Business.Concrete;
using Convice.Entities.IdentityEntities;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Convice.WebMVCUI
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
            // Dependenies Injected
            services.AddScoped<IContentService,ContentManager>();
            services.AddScoped<IContentDal, EfContentDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<IPlatformService, PlatformManager>();
            services.AddScoped<IPlatformDal, EfPlatformDal>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();

            services.AddSession();
            services.AddDbContext<CustomIdentityContext>(
                options => 
                options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Convice;Trusted_Connection=true")
                );
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
                .AddEntityFrameworkStores<CustomIdentityContext>()
                .AddDefaultTokenProviders();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath,"node_modules")),
                RequestPath = new PathString("/node_modules")
            });
            app.UseCookiePolicy();

            app.UseAuthentication();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
