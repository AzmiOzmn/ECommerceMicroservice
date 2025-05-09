using ECommerce.Order.Application.Features.CQRS.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ECommerce.Order.Application.Extensions
{
   public static class ApplicationRegistrations
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<GetAdressQueryHandler>();
            services.AddScoped<GetAdressByIdQueryHandler>();

        }
    }
}
