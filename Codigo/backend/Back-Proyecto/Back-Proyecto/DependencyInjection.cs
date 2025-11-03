using Back_Proyecto.Context;
using Back_Proyecto.Repositories;
using Back_Proyecto.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back_Proyecto
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration _configuration)
        {
            string connectionString = _configuration["ConnectionStrings:SQLConnectionStrings"];

            services.AddDbContext<CafDataContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IUsersRepository, UserRepository>();

            

            return services;
        }
    }
}
