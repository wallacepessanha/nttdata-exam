using Microsoft.EntityFrameworkCore;
using NTTData.Sale.Infra.Data;

namespace NTTData.Sale.API.Configuration
{
    public static class ApiConfig
    {
        public static void AddSql(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SalesContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
