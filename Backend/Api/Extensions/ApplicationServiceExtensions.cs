﻿using Core.Interfaces;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static void AddApplicationServices( this IServiceCollection services )
        {
            services.AddScoped ( typeof(IGenericRepository<>), typeof(GenericRepository<>) );
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}