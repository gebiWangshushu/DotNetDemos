using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Com.Ctrip.Framework.Apollo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApi.Hei.Apollo.Controllers
{
    [Route("api/[controller]/{key}")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IConfiguration _configuration;
        public ValuesController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get(string key)
        {
            var value = _configuration.GetValue<string>(key);
            return Ok($"key:{key} value:{value}");
        }
    }
}
