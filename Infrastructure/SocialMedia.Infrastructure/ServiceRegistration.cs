using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Application.Abstractions.Storage;
using SocialMedia.Application.Abstractions.Storage.Azure;
using SocialMedia.Application.Abstractions.Storage.Local;
using SocialMedia.Application.Abstractions.Token;
using SocialMedia.Infrastructure.Services.Storage;
using SocialMedia.Infrastructure.Services.Storage.Azure;
using SocialMedia.Infrastructure.Services.Storage.Local;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, Token.TokenHandler>();
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<ILocalStorage, LocalStorage>();
            services.AddScoped<IAzureStorage, AzureStorage>();
        }

        public static void AddStorage<T>(this IServiceCollection services) where T: class, IStorage
        {
            services.AddScoped<IStorage, T>();
        }
    }
}
