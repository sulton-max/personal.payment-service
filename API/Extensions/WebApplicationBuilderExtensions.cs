using PaypalPayment.Services;
using PaypalPayment.Services.Interfaces;

namespace API.Extensions;

public static class WebApplicationBuilderExtensions
{

    public static IServiceCollection AddCustomRouting(this IServiceCollection services)
    {
        services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
        });

        return services;
    }
    
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IPaymentService, PaymentService>();
        
        return services;
    }
    
}