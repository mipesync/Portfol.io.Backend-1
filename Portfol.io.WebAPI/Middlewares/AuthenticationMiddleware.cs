using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Portfol.io.WebAPI.Middlewares
{
    public static class AuthenticationMiddleware
    {
        public static IServiceCollection AddAuthenticationMiddleware(this IServiceCollection services)
        {
            services.AddAuthentication(conf =>
            {
                conf.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                conf.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = AuthenticationOptions.ISSUER,
                    ValidateAudience = true,
                    ValidAudience = AuthenticationOptions.AUDIENCE,
                    ValidateLifetime = true,
                    IssuerSigningKey = AuthenticationOptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true
                };
            });

            return services;
        }
    }
}
