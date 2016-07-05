using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication.Handlers
{
    public class MethodOverrideMessageHandler: DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //Request
            if (request.Method == HttpMethod.Post)
            {
                var headervalues = request.Headers.Where(o => o.Key == "X-HTTP-Method-Override").Select(o => o.Value).SingleOrDefault();
                if (headervalues !=null && headervalues.Any())
                {
                    var hv = headervalues.First();
                    request.Method = new HttpMethod(hv);
                }
            }
            var watch = Stopwatch.StartNew();
            var result = await base.SendAsync(request, cancellationToken);

            //Result
            var ms = watch.ElapsedMilliseconds;
            Debug.WriteLine(string.Format("Method: {0} Timer: {1} ms", request.Method, ms));
            return result;
        }
    }
}