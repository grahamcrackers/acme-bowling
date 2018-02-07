using ACME.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ACME.Api.Controllers
{
    [Route("api/greeting")]
    public class GreetingController : Controller
    {
        private readonly GreetingBuilder _greetingBuilder;

        public GreetingController()
        {
            _greetingBuilder = new GreetingBuilder();
        }

        [HttpGet]
        public dynamic Get()
        {
            return new {Text = _greetingBuilder.Build()};
        }

        [HttpGet("{name}")]
        public dynamic GetByName(string name)
        {
            return new {Text = _greetingBuilder.Build(name)};
        }
    }
}