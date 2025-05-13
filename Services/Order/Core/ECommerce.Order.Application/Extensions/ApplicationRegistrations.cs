using ECommerce.Order.Application.Features.CQRS.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;



namespace ECommerce.Order.Application.Extensions
{
   public static class ApplicationRegistrations
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<GetAdressQueryHandler>();
            services.AddScoped<GetAdressByIdQueryHandler>();
            services.AddScoped<CreateAdressCommandHandler>();
            services.AddScoped<UpdateAdressCommandHandler>();
            services.AddScoped<RemoveAdressCommandHandler>();
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

        }
    }
}
