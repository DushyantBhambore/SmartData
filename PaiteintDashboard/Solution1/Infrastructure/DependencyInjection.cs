using App.Core.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfigurationManager configurationManager)
        {
            services.AddTransient<IAppDbContext, AppDbContext>();

            services.AddDbContext<AppDbContext>((provider, options) =>
            {

                options.UseSqlServer(configurationManager.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
            });

            return services;
        }

    }
}
