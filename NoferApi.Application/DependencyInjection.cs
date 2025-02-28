using Microsoft.Extensions.DependencyInjection;

namespace NoferApi.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            // config.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
            // config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
        });

        // services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);

        return services;
    }
}
