using System.Diagnostics;
using Task1.Abstractions;
using Task1.Models;

namespace Task1.Middleware
{
    public class ResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        public ResponseLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IDbContext dbContext)
        {
            var requetsDate = DateTime.UtcNow;

            var originalBodyStream = context.Response.Body;

            Stopwatch watch = Stopwatch.StartNew();
            await _next(context);
            watch.Stop();

            await dbContext?.AddAsync<ResponseLogModel>(new ResponseLogModel
            {
                Duration = watch.ElapsedMilliseconds,
                RequestDate = requetsDate,
                Type = context.Request.Method,
                Path = context.Request.Path.Value,
                ResponseCode = context.Response.StatusCode
            });
            await dbContext?.CommitChanges();
        }
    }
}
