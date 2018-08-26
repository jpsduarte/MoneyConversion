using Microsoft.AspNetCore.Mvc;
using MoneyConversion.Api.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MoneyConversion.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        public static string ACCESS_KEY = "0307515030c346d6d5fe49619b22e49f";
        public static string BASE_URL = "http://apilayer.net/api/";

        [HttpGet]
        public async Task<IActionResult> Get(string from, string to, double amount)
        {

            if (string.IsNullOrEmpty(from))
                return BadRequest("from is missing");

            if (string.IsNullOrEmpty(to))
                return BadRequest("to is missing");

            if (amount == 0)
                return Ok(0);

            using (var http = new HttpClient { BaseAddress = new Uri(BASE_URL) })
            {
                string parameters = string.Empty;

                //TODO: consultar lista de cotações da apilayer

                parameters = "?access_key=" + ACCESS_KEY + "&format=1";

                using (var response = await http.GetAsync("live" + parameters))
                {
                    response.EnsureSuccessStatusCode();

                    //TODO: parsear resultado com o newtonsoft para obter lista de cotações
                    var content = await response.Content.ReadAsStringAsync();
                    var liveResponse = JsonConvert.DeserializeObject<LiveRequest>(content);

                    //TODO: converter valores e validações de moeda

                    if (!liveResponse.Quotes.ContainsKey(from))
                    {
                        return BadRequest("source currency not found");
                    }

                    if (!liveResponse.Quotes.ContainsKey(to))
                    {
                        return BadRequest("destination currency found");
                    }

                    var fromValue = liveResponse.Quotes[from];
                    var toValue = liveResponse.Quotes[to];

                    return Ok(toValue / fromValue * amount);
                }
            }
        }
    }
}