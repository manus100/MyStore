using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace MyStore.Infrastructure
{
    public class SecurityHeaderMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IConfiguration config;
        private const string APIKeyName = "AppAPIKey";
        public SecurityHeaderMiddleware(RequestDelegate next, IConfiguration config)
        {
            this.next = next;
            this.config = config;
        }

        //public async Task Invoke(HttpContext httpcontext)
        //{
        //    httpcontext.Response.Headers.Add("We", "AreAwesome");  //am pus in headerul raspunsului si dau mai departe
        //    await this.next.Invoke(httpcontext);
        //}

        public async Task Invoke(HttpContext context)
        {
            //testez ca in headerul requestului am un APIKeyName
            if (!context.Request.Headers.TryGetValue("APIKey", out var requestedApiKey))
            {
                //daca nu trimite ApiKey => status code 401 - Unauthorized
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key was not provided!");
                return;
            }

            //citesc din AppSettings valoarea pentru APIKey
            var apiKey = config.GetValue<string>("AppSettings:APIKey");

            //conmpar ca valoarea din headerul de request este egala cu ce am in appSettings
            if (!apiKey.Equals(requestedApiKey))
            {
                //ApiKey incorect => status code 403 - Forbidden
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Invalid API Key!");
                return;
            }

            await this.next.Invoke(context);
        }

    }
}
