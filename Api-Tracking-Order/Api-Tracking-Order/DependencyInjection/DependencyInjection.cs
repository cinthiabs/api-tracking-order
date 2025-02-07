using Application.Interface;
using Application;
using Infra.DapperConfig;
using Infra.Repository;
using Service.Interface;
using Service.Service;
using Domain.Interface;

namespace Api_Tracking_Order.DependencyInjection
{
    public static partial class DependencyInjection
    {
        public static void AddConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IRegistration, Registration>();
            services.AddScoped<IApplicationTracking, ApplicationTracking>();
            services.AddScoped<IConnection, Connection>();
        }
    }
}
