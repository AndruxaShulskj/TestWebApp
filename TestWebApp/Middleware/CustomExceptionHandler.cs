using Newtonsoft.Json;

namespace TestWebApp.Middleware
{
    public class CustomExceptionHandler(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(Exception ex)
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
 
                await context.Response.WriteAsync(JsonConvert.SerializeObject(ex.Message));
            }
        }
    }
}
