using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filtros.Filters;

public class LoggingActionAttribute : Attribute, IAsyncActionFilter
{
    private readonly ILogger<LoggingActionAttribute> _logger = new LoggerFactory().CreateLogger<LoggingActionAttribute>();

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var controller = context.RouteData.Values["controller"];
        var action = context.RouteData.Values["action"];
        var arguments = JsonSerializer.Serialize(context.ActionArguments);
        Console.WriteLine($"Executing action {controller}/{action} with arguments: {arguments}");

        var resultnext = await next();

        var objectResult = resultnext.Result as ObjectResult;
        if (objectResult != null)
        {
            var result = JsonSerializer.Serialize(objectResult.Value);
            Console.WriteLine($"Executed action {controller}/{action} with result: {result}");
        }
    }
}