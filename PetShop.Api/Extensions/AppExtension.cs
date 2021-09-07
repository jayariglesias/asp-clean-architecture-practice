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

        public static void UseSwaggerExtension(this IApplicationBuilder app) // NOT FINISHED
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PetShop.Api");
            });
        }
    }
}
