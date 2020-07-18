using Microsoft.Extensions.DependencyInjection;
using STI.Services.Contracts;
using STI.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STI.API
{
    public partial class Startup
    {
        public void ConfigureDIServices(IServiceCollection services) 
        {
            services.AddScoped<IWarehouseService, WarehouseService>();
        }
    }
}
