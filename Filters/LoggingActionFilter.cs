using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filtros.Filters;

public class LoggingActionFilter : IAsyncActionFilter
{
    private readonly ILogger<LoggingActionFilter> _logger;

    public LoggingActionFilter(ILogger<LoggingActionFilter> logger)
    {
        _logger = logger;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var controller = context.RouteData.Values["controller"];
        var action = context.RouteData.Values["action"];
        var arguments = JsonSerializer.Serialize(context.ActionArguments);
        _logger.LogInformation($"Executing action {controller}/{action} with arguments: {arguments}");

        var resultnext = await next();

        var objectResult = resultnext.Result as ObjectResult;
        if (objectResult != null)
        {
            var result = JsonSerializer.Serialize(objectResult.Value);
            _logger.LogInformation($"Executed action {controller}/{action} with result: {result}");
        }
    }
}