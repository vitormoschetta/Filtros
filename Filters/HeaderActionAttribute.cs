using Microsoft.AspNetCore.Mvc.Filters;

namespace Filtros.Filters
{
    public class HeaderActionAttribute : Attribute, IAsyncActionFilter
    {
        private readonly string _name;
        private readonly string[] _values;

        public HeaderActionAttribute(string name, params string[] values)
        {
            _name = name;
            _values = values;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var headers = context.HttpContext.Request.Headers;

            if (headers.ContainsKey(_name))
            {
                Console.WriteLine($"Header {_name} found with value {headers[_name]}");
            }
            else
            {
                Console.WriteLine($"Header {_name} not found");
            }

            await next();            
        }
    }   
}