using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UnalColombia.Common.Extensions.Program
{
    public static class StartupServiceExtension
    {

        public static IServiceCollection SetPhysicalPolicy(this IServiceCollection service, string policyName)
        {
            service.AddCors(o => o.AddPolicy(policyName, builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            return service;
        }

        public static IServiceCollection AddBearerAuthentication(this IServiceCollection service, string authorityUrl)
        {
            service
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer("Bearer", options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.Authority = authorityUrl;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });
            return service;
        }

        public static IServiceCollection AddScopesPolicy(this IServiceCollection service, string serviceName, List<string> scopes)
        {
            service
               .AddAuthorization(options =>
               {
                   foreach (var scope in scopes)
                   {
                       options.AddPolicy(scope, policy => policy.RequireClaim("scope", serviceName + "." + scope));
                   }

               });
            return service;
        }

        public static IServiceCollection ConfigureJsonPreferences(this IServiceCollection service)
        {
            service.Configure(delegate (JsonOptions options)
            {
                options.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.SerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
                options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.SerializerOptions.AllowTrailingCommas = true;
            });
            return service;
        }
    }

}
