using MachineTrace.Application.Mappings;
using MachineTrace.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MachineTrace.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICategoryService, CategoryService>();
            serviceCollection.AddAutoMapper(typeof(MachineTraceMappingProfile));
        }
    }
}
