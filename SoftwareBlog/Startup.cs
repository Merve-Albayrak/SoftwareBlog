using Business.Abstract;
using Business.Concrete;
using Data.Abstract;
using Data.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoftwareBlog.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareBlog
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)


        {
            services.AddScoped<BlogContext>();
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();//þifre sýfýrlamamda benzersiz token
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(_configuration.GetConnectionString("PostgressqlConnetionString")));
            services.AddControllersWithViews();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IBlogPostService, BlogPostManager>();
            //services.AddScoped<ICommentRepository, Comment>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles(); //wwwrootu kullanýr
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
          //  app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


                endpoints.MapControllerRoute(
                    name: "register",
                    pattern: "{action}",

                   defaults: new{ controller="Account",action="Register"}
                    );



            }); 
        }
    }
}
