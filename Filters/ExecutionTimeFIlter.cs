using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace HotelBookingAPI.Filters
{
    public class ExecutionTimeFIlter : IActionFilter
    {
        private Stopwatch _stopwatch;

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ExecutionTimeLog.txt");

            File.WriteAllTextAsync(filePath, $"Action {context.ActionDescriptor.DisplayName} executed in {_stopwatch.ElapsedMilliseconds}");
        }
    }
}
