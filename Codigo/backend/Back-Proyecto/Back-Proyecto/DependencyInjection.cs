using Back_Proyecto.Context;
using Back_Proyecto.Models;
using Back_Proyecto.Repositories;
using Back_Proyecto.Repositories.Implementations;
using Back_Proyecto.Repositories.interfaces;
using Back_Proyecto.Repositories.Interfaces;
using Back_Proyecto.Services;
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
            services.AddScoped<IDiscounts, DiscountsRepository>();
            services.AddScoped<IGlobalDiscounts, GlobalDiscountsRepository>();
            services.AddScoped<IDiscountedProducts, DiscountedProductsRepository>();
            services.AddScoped<IPriceHistory, PriceHistoryRepository>();
            services.AddScoped<ISales,SalesRepository >();
            services.AddScoped<IUsers_Sessions, UserSessionsRepository>();
            services.AddScoped<ISale_Detail,SaleDetailRepository >();
            services.AddScoped<ICoupons, CouponsRepository>();
            services.AddScoped<ICompany, CompanyRepository>();
            services.AddScoped<IAttendanceLogService, AttendanceLogRepository>();
            services.AddScoped<ISystemLogService,SystemLogRepository >();
            services.AddScoped<IUserSheduleService, UserSheduleRepository>();



            return services;
        }
    }
}
