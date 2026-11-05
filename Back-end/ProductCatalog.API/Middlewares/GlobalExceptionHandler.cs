using Application.Commons.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ProductCatalog.API.Middlewares
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Произошло необработанное исключение: {Message}", exception.Message);

            int statusCode = StatusCodes.Status500InternalServerError;
            string title = "Internal Server Error";
            string detail = exception.Message;

            if (exception is BaseException baseException)
            {
                statusCode = (int)baseException.StatusCode;

                title = baseException.GetType().Name.Replace("Exception", "");
                detail = baseException.Message;
            }

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = detail,
                Instance = httpContext.Request.Path.Value
            };

            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/json";

            await JsonSerializer.SerializeAsync(
                httpContext.Response.Body,
                problemDetails,
                cancellationToken: cancellationToken);

            return true;
        }
    }
}
