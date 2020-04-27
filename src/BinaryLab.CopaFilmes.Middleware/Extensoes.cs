using Microsoft.AspNetCore.Builder;

namespace BinaryLab.CopaFilmes.Middleware
{
    public static class Extensoes
    {
        public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder app)
        {
            app.UseExceptionMiddleware().UseNotificationMiddleware();

            return app;
        }

        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();

            return app;
        }

        public static IApplicationBuilder UseNotificationMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<NotificationMiddleware>();

            return app;
        }
    }
}
