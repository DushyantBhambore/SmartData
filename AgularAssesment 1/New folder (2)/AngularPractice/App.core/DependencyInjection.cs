using App.core.App.Employee.Command;
using Microsoft.Extensions.DependencyInjection;

namespace App.core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<CreateEmployeeCommand>();
            });
            return services;
        }

    }
}
