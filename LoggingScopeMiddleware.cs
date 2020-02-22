using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiSerilog
{
    public class LoggingScopeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        private static long ScopeId;

        public LoggingScopeMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<LoggingScopeMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            using (_logger.BeginScope(Interlocked.Increment(ref ScopeId)))
            {
                await _next(context);
            }
        }
    }
}