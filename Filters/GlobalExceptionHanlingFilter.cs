using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HotelBookingAPI.Filters
{
    public class GlobalExceptionHanlingFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var response = new
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = "Uexpected error occured",
                DetailedException = context.Exception.GetFullMessage()
            };

            List<string> errors = new List<string>();
            errors.Add(response.StatusCode.ToString());
            errors.Add(response.Message);
            errors.Add(response.DetailedException);

            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "RequestResponseLog.txt");
            File.WriteAllTextAsync(filePath, string.Join("-->", errors));

            context.Result = new ObjectResult(response)
            {
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
            context.ExceptionHandled = true;
        }
    }
}
