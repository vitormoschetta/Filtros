using Microsoft.AspNetCore.Mvc.Filters;

namespace Filtros.Filters
{
    public class ResponseActionAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Response-Action", "ResponseActionAttribute");

            // console write response body here:
            var response = context.HttpContext.Response;
            var body = response.Body;
            var reader = new StreamReader(body);
            var text = reader.ReadToEnd();
            Console.WriteLine(text);
            body.Seek(0, SeekOrigin.Begin);                        

            base.OnResultExecuting(context);
        }
    }
}