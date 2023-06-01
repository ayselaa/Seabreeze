using Newtonsoft.Json;
using System.Net;

namespace Api
{

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Create a custom error response object
            var errorResponse = new ErrorResponse
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            };

            // Convert the response object to JSON
            var jsonResponse = JsonConvert.SerializeObject(errorResponse);

            // Return the JSON response to the client
            await context.Response.WriteAsync(jsonResponse);
        }
    }

    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }

    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }

}
