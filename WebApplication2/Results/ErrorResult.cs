using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApplication.Results
{
    public class ErrorResult : IHttpActionResult
    {
        private Exception _e;

        public ErrorResult(Exception e)
        {
            _e = e;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage()
            {
                Content = new StringContent(_e.Message),
                StatusCode = System.Net.HttpStatusCode.InternalServerError
            };
            return Task.FromResult(response);
        }
    }
}