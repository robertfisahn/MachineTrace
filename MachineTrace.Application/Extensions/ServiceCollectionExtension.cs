using FluentValidation;
using FluentValidation.AspNetCore;
using MachineTrace.Application.Commands.Category.Create;
using MachineTrace.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MachineTrace.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            serviceCollection.AddAutoMapper(typeof(MachineTraceMappingProfile));
            serviceCollection.AddValidatorsFromAssemblyContaining<CreateCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

        }
    }
}
