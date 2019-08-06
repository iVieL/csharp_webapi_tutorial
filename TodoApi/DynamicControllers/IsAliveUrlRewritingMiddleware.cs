using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TodoApi.DynamicControllers
{
    public class IsAliveUrlRewritingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _overridedRoot;

        public IsAliveUrlRewritingMiddleware(RequestDelegate next, string parent)
        {
            _next = next;
            _overridedRoot = parent;
        }

        public Task Invoke(HttpContext context)
        {
            var path = context.Request.Path.ToUriComponent();
            if (PathIsAliveRequest(path))
            {
                context.Request.Path = "/isalive";
            }

            var task = _next.Invoke(context);
            task.Wait();
            return task;
        }

        private bool PathIsAliveRequest(string path)
        {
            return path.ToLower().Equals($"/{_overridedRoot}/isalive");
        }
    }
}