using App.core.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastruture(this IServiceCollection services, IConfigurationManager configuration)
        {
            services.AddTransient<IAppDBContext, AppDbContext>();

            services.AddDbContext<AppDbContext>((provider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
            });
            return services;

        }
    }
}
