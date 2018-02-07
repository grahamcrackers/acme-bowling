using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACME2.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ACME.Api.Controllers
{
    [Route("api/greeting")]
    public class GreetingController : Controller
    {
        [HttpGet]
        public dynamic Get()
        {
            var greetingBuilder = new GreetingBuilder();

            return new { Text = greetingBuilder.Build() };
        }
    }
}
