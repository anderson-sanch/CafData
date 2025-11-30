using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories;
using Back_Proyecto.Repositories.Implementations;
using Back_Proyecto.Repositories.interfaces;
using Back_Proyecto.Repositories.Interfaces;
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
            services.AddScoped<IRoles, RolesRepository>();
            services.AddScoped<IPermissions, PermissionsRepository>();
            services.AddScoped<IRolesPermissions, RolesPermissionsRepository>();
            services.AddScoped<IClientsRepository, ClientsRepository>();
            services.AddScoped<ICategories, CategoriesRepository>();
            services.AddScoped<IProducts, ProductsRepository>();





            return services;
        }
    }
}
