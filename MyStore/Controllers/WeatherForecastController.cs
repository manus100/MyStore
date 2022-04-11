using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MyStore.Infrastructure;

namespace MyStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration config;
        private readonly IOptions<MySettings> appSettings;
        private readonly MySettings mySettings;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration config,
            IOptions<MySettings> appSettings)
        {
            _logger = logger;
            this.config = config;
            this.appSettings = appSettings;  //store as it is -> cand iau valorile din clasa MySettings
            this.mySettings = appSettings.Value;   //strip it from IOptions interface - var 2 cand iau din clasa
        }

        [HttpGet]
       public async Task<IActionResult> GetWeatherAsync() 
        {
            //var openWeatherUrl = config.GetSection("MySettings").GetSection("OpenWeatherMapUrl").Value;
            //var apiKey = config.GetSection("MySettings").GetSection("ApiKey").Value;

            var openWeatherUrl = config.GetValue<string>("MySettings:OpenWeatherMapUrl");
            var apiKey = config.GetValue<string>("MySettings:ApiKey");

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{openWeatherUrl} {apiKey}");
            //HttpResponseMessage response = await client.GetAsync($"{mySettings.OpenWeatherMapUrl} {appSettings.Value.ApiKey}");  //daca luam valorile din clasa - var cu mySettings si appSettings

            var contentData = string.Empty;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)   //testez intai ca s-a terminat de executat, altfel nu o sa am date in response
            {
                //chestii
                 contentData = response.Content.ReadAsStringAsync().Result;  //next step: deserialized the json
            }

            return Ok(contentData);
        }

    
    }
}
