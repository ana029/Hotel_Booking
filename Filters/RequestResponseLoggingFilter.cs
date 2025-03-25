using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace HotelBookingAPI.Filters
{
    public class RequestResponseLoggingFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "RequestResponseLog.txt");

            var request = await FormatRequest(context.HttpContext.Request);

            File.WriteAllTextAsync(filePath, request);

            var executedContext = await next();

            var response = await FormatResponse(executedContext.HttpContext.Response);

            string responseContent = response.ToString();

            File.WriteAllTextAsync(filePath, response);
        }

        private async Task<string> FormatRequest(HttpRequest request)
        {
            request.EnableBuffering();

            var body = request.Body;

            using var reader = new StreamReader(body, Encoding.UTF8, leaveOpen: true);
            var bodyText = await reader.ReadToEndAsync();
            body.Seek(0, SeekOrigin.Begin);

            return $"Method: {request.Method}, Path: {request.Path}, Body: {bodyText}";
        }

        private async Task<string> FormatResponse(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);

            using var reader = new StreamReader(response.Body, Encoding.UTF8, leaveOpen: true);
            var bodyText = await reader.ReadToEndAsync();

            return $"Status: {response.StatusCode}, Body: {bodyText}";
        }
    }
}
