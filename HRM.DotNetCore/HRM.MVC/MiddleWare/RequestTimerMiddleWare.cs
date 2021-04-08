using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.MVC.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestTimerMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;


        public RequestTimerMiddleWare(RequestDelegate next, ILoggerFactory logFactory)
        {
            _next = next;

            _logger = logFactory.CreateLogger("RequestTimerMiddleWare");
        }

        public Task Invoke(HttpContext httpContext)
        {
            var watch = new Stopwatch();
            watch.Start();
            httpContext.Response.OnStarting(() => {
                // Stop the timer information and calculate the time   
                watch.Stop();
                var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;
                // Add the Response time information in the Response headers.   
                _logger.LogInformation(responseTimeForCompleteRequest.ToString());
                return Task.CompletedTask;
            });
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestTimerMiddleWareExtensions
    {
        public static IApplicationBuilder UseRequestTimerMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestTimerMiddleWare>();
        }
    }
}
