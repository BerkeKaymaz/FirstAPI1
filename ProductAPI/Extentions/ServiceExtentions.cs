using Application.Interfaces;
using Application.Services;
using Domain.Repositories;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Extentions
{
    public static class ServiceExtentions
    {
        public static WebApplicationBuilder AddCustomServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddDbContext<MySQLContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("ConnectionString"), b => b.MigrationsAssembly("ProductAPI")));
            return builder;
        }
    }
}
