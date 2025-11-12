
namespace TodoApp.API.Middlewares
{
    public class HttpRequestMiddleware : IMiddleware
    {
        private ILogger<HttpRequestMiddleware> _logger;
        public HttpRequestMiddleware(ILogger<HttpRequestMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _logger.LogInformation($"Request:{context.Request.Path}");
            await next(context);
        }
    }
}
