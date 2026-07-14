//MediatR handler’larını kaydetmek
//Daha sonra validator ve pipeline behavior’ları kaydetmek
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MiniStock.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // MediatR'ı bu katmandaki (Application) assembly'den bularak kaydeder
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        return services;
    }
}