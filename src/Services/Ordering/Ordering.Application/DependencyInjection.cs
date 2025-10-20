using BuildingBlocks.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;


namespace Ordering.Application
{
   public static class DependencyInjection
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {

            services.AddMediatR(config =>
            {

                //“Scan this assembly(the current project — e.g., Ordering.Application) and automatically 
                //register all classes that implement any MediatR interfaces.”
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddBehavior(typeof(ValidationBehavior<,>));
                config.AddBehavior(typeof(LoggingBehavior<,>));

            });

                return services;

        }
    }
}
