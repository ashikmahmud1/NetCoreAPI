using System.Linq;
using API.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IProductRepository, ProductRepository>(); // appropriate for injecting services to be available in our application
            services.AddScoped<IBasketRepository, BasketRepository>();
            // Way to inject the generic service. As we don't know the type of the service
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));

                services.Configure<ApiBehaviorOptions>(options => {
                options.InvalidModelStateResponseFactory = actionContext => 
                {
                    var errors = actionContext.ModelState
                    .Where( e => e.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationError
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(errorResponse);

                };
            });
            return services;
        }
    }
}