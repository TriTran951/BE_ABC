namespace BE_ABC.Middlewares
{
    public class NotFoundMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<NotFoundMiddleware> _logger;
        public NotFoundMiddleware(RequestDelegate next, ILogger<NotFoundMiddleware> logger)
        {
            _next = next;
            this._logger = logger;
        }
        public async Task Invoke(HttpContext context)
        {
            await _next(context);

            if(context.Response.StatusCode == 404) 
            {
                _logger.LogInformation($"Handle 404 error for request {context.Request.Path}");

                context.Response.StatusCode = 404;
                context.Response.ContentType = "text/html";

                await context.Response.WriteAsync("<html><body><h1>404 - Page not found</h1></body></html>");
            }
        }
    }
}
