using ContactsApplication.Infrastructure.Middleware;

namespace ContactsApplication.API.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseDataSeeder(this WebApplication app)
        {
            return app.UseMiddleware<DataSeedingMiddleware>();
        }
    }
}
