using BLL.Interface.Servicies;
using BLL.Servicies;
using DAL.Interface.Repositories;
using DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ORM.EF;
using Web.UI.Infrastructure;

namespace Web.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CourseWorkContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("Connection")));
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IMentorRepository, MentorRepository>();
            services.AddScoped<ICourseWorkRepository, CourseWorkRepository>();
            services.AddScoped<ICourseWorkService, CourseWorkService>();
            services.AddScoped<IMessageSender, MailMessageSender>();
            services.AddScoped(typeof(MappingProfileWeb));
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            
            SeedData.EnsurePopulated(app);
        }
    }
}