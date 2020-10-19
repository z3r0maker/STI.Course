using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using STI.API;
using STI.Course.DTO;
using STI.Data;
using STI.Services.Contracts;
using STI.Services.Services;

namespace STI.Course
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<IUserService, UserService>();

            var conectionString = Configuration.GetConnectionString("DefaultConnection");

            //var configSection = Configuration.GetSection("MyConfigurationSection"); // array de configuraciones

            //la configuracion que no esta dentro de ninguna seccion
            var dataAssembly = Configuration["DataAssembly"];

            services.AddDbContextPool<STIContext>(option =>
            {
                option.UseSqlServer(conectionString, sql=> sql.MigrationsAssembly(dataAssembly));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
