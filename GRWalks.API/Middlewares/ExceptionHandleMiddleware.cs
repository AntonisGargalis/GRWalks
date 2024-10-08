using System.Net;

namespace GRWalks.API.Middlewares
{
    public class ExceptionHandleMiddleware
    {
        private readonly ILogger<ExceptionHandleMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandleMiddleware(ILogger<ExceptionHandleMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();

                // Log this Exception
                _logger.LogError(ex, $"{errorId} : {ex.Message}" );

                // Return A Custom Error Response
                httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = "Something went wrong..."
                };

                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }
}
