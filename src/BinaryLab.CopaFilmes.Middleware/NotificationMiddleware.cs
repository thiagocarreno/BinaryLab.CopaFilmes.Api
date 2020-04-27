using System.Net;
using System.Threading.Tasks;
using BinaryLab.CopaFilmes.Http;
using BinaryLab.CopaFilmes.Validacao.Abstractions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BinaryLab.CopaFilmes.Middleware
{
    public class NotificationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly INotificationContext _notificationContext;

        public NotificationMiddleware(RequestDelegate next, INotificationContext notificationContext)
        {
            _next = next;
            _notificationContext = notificationContext;
        }

        public async Task Invoke(HttpContext context)
        {
            if (_notificationContext.HasNotifications)
            {
                context.Response.ContentType = TiposConteudo.Json;
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                var notifications = JsonConvert.SerializeObject(_notificationContext.Notifications);
                await context.Response.WriteAsync(notifications);
                return;
            }

            await _next(context);
        }
    }
}
