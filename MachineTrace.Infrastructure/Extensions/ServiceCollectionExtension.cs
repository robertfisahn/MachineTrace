using MachineTrace.Domain.Intefaces;
using MachineTrace.Infrastructure.Persistence;
using MachineTrace.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MachineTrace.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<MachineTraceDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

            serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
