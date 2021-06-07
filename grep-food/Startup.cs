using grep_food.DataAccess;
using grep_food.DomainEntitiesMappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace grep_food
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
            Console.WriteLine("before ree");
            string cs= "Data Source=(localdb)\\ProjectsV13;Initial Catalog=grep-food.database;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open(); // throws if invalid
            }
            Console.WriteLine("after ree");
          

        }

        public IConfiguration Configuration { get; }
        

// This method gets called by the runtime. Use this method to add services to the container.
public void ConfigureServices(IServiceCollection services)
        {
            //services.AddScoped<IDataRepository, DataContext>();
            services.AddControllersWithViews();
            services.AddTransient<IUnitOfWork, DataContext>();
            services.AddTransient<IDataRepository, DataContext>();

            //services.AddScoped<IDataRepository, DataContext>();
            var connection = Configuration.GetConnectionString("grep-food");
            Console.WriteLine($"connection: '{connection}'");
            services.AddDbContext<DataContext>(opt =>
            opt.UseSqlServer(Configuration.GetConnectionString("grep-food")));

          

            // Refactor to separate method

            services.AddTransient<IEntityTypeConfigurationRegistrar, EntityTypeConfigurationRegistrar>();
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
