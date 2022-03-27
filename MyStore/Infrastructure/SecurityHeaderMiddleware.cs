using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyStore.Infrastructure
{
    public class SecurityHeaderMiddleware
    {
        private readonly RequestDelegate next;
        public SecurityHeaderMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpcontext)
        {
            httpcontext.Response.Headers.Add("We", "AreAwesome");
            await this.next.Invoke(httpcontext);
        }
    }
}
