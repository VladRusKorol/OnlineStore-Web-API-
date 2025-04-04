﻿using OnlineStore.Entity;
using OnlineStore.Persistence;
using OnlineStore.Repository;
using OnlineStore.Repository.Interfaces;

namespace OnlineStore.WebAPI.Extentions;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        services.AddDbContext<OnlineStoreDBContext>();

        services.AddScoped<IRepositoryBase<Category>>(x => {
            return new CategoryRepository(new OnlineStoreDBContext());
        });

        services.AddScoped<IRepositoryBase<Product>>(x => {
            return new ProductRepository(new OnlineStoreDBContext());
        });

        return services;
    }
}
