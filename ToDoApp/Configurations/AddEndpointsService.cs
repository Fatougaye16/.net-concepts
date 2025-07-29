using System.Reflection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ToDoApp.Configurations;

public static class AddEndpointsService
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
    {
        ServiceDescriptor[] descriptors = assembly.DefinedTypes.Where(type => type is {IsAbstract: false, IsInterface: false} && type.IsAssignableTo(typeof(IEndpoint)))
            .Select(type => ServiceDescriptor.Transient(typeof(IEndpoint), type))
            .ToArray();
        
        services.TryAddEnumerable(descriptors);
        return services;
    }
}