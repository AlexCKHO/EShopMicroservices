using BuildingBlocks.Exceptions.Handler;


namespace Ordering.API
{
    public static class DependencyInjection
    {


        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddCarter();

            services.AddExceptionHandler<CustomExcetionHandler>();

            return services;

        }

        public static WebApplication UseApiServices(this WebApplication app) {

            app.MapCarter();

            app.UseExceptionHandler(options => { });
        
            return app;
        
        }
    }
}
