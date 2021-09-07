using Microsoft.AspNetCore.Builder;
using PetShop.Api.Middlewares;

namespace PetShop.Api.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }

        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "PetShop API");
            });
        }
    }
}
