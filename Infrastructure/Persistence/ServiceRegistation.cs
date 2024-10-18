using Application;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class ServiceRegistation
    {
        //static ;class ayağa kalktıktan sonra değişmiycek.
        //static class ın içerisinde static method
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddScoped <IDeviceRepository, DeviceRepository> ();
            services.AddScoped<IPingRepo,PingRepository> ();


        }
    }
}

