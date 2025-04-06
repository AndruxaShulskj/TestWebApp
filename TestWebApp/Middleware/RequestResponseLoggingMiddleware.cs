using System.Diagnostics;
using System.Text;
using Microsoft.IO;
using TestWebApp.Business.Interfaces;
using TestWebApp.Business.Models;

namespace TestWebApp.Middleware
{
    public class RequestResponseLoggingMiddleware(RequestDelegate next)
    {
        private readonly RecyclableMemoryStreamManager _recyclableMemoryStreamManager = new();

        public async Task Invoke(HttpContext context, ILogDataService logDataService)
        {
            var requetsDate = DateTime.UtcNow;
            var originalBodyStream = context.Response.Body;
            var request = await GetRequestAsync(context.Request);

            await using var responseBody = _recyclableMemoryStreamManager.GetStream();
            context.Response.Body = responseBody;

            var watch = Stopwatch.StartNew();
            await next(context);
            watch.Stop();

            var response = await GetResponseAsync(context.Response);

            await logDataService.Create(new LogData()
            {
                Duration = watch.ElapsedMilliseconds,
                Request = request,
                Date = requetsDate,
                Response = response,
                Code = context.Response.StatusCode
            });

            await context.Response.Body.CopyToAsync(originalBodyStream);
        }

        private async Task<string> GetResponseAsync(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);

            var text = await new StreamReader(response.Body).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            return text;
        }

        private async Task<string> GetRequestAsync(HttpRequest request)
        {
            request.EnableBuffering();
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);
            var bodyText = Encoding.UTF8.GetString(buffer);
            request.Body.Position = 0;

            return $"Scheme: {request.Scheme}\nMethod: {request.Method}\nUrl: {request.Host}{request.Path}\nQueryString: {request.QueryString}\nBody: {bodyText}";
        }
    }
}
