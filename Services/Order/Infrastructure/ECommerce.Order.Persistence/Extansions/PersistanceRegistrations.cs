﻿using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Persistence.Concrete;
using ECommerce.Order.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Order.Persistence.Extansions
{
    public static class PersistanceRegistrations
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
             {
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));


             });

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

    }
}
