using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Application.Abstractions.Repositories;
using SocialMedia.Application.Abstractions.Services;
using SocialMedia.Application.Abstractions.Token;
using SocialMedia.Application.Abstractions.UnitOfWork;
using SocialMedia.Domain.Entities;
using SocialMedia.Persistance.Contexts;
using SocialMedia.Persistance.Repositories;
using SocialMedia.Persistance.Services;
using SocialMedia.Persistance.UnitOfWork;
using System.Security.Claims;
using System.Text;

namespace SocialMedia.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<SocialMediaDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new()
                {

                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"])),
                    LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,
                    ValidIssuer = configuration["Token:Issuer"],
                    ValidAudience = configuration["Token:Audience"],
                    NameClaimType = ClaimTypes.Name
                };

            });

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<SocialMediaDbContext>();

            //repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IFriendshipRepository, FriendshipRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<IDislikeRepository, DislikeRepository>();

            //services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IFriendshipService, FriendshipService>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
            services.AddScoped<ILikeDislikeService, LikeDislikeService>();
            services.AddScoped<IAuthService, AuthService>();

            

        }
    }
}
