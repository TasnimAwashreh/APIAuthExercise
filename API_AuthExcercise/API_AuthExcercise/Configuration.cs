using API_AuthExcercise.API;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API_AuthExcercise
{
    public static class Configuration
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            services.AddSingleton<IConfiguration>(config);
            services.AddSingleton<JwtTokenGenerator>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtToken:Key"])),
                        ValidIssuer = config["JwtToken:Issuer"],
                        ValidAudience = config["JwtToken:Audience"],
                        ValidateLifetime = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                    };
                });

            return services;
        }
    }
}
