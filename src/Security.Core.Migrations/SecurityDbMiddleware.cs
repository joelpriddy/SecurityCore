using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Security.Core.Migrations
{
    public class SecurityDbMiddleware<TContext> where TContext : DbContext
    {
        private readonly RequestDelegate _next;

        public SecurityDbMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, TContext dbContext)
        {
            // Applies ALL migrations in this library
            await dbContext.Database.MigrateAsync();

            // Proceed to the next middleware
            await _next(context);
        }
    }
}
