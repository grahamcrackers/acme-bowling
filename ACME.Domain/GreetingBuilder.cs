namespace ACME.Domain
{
    public class GreetingBuilder
    {
        private static IDataService _dataService;

        public GreetingBuilder()
        {
        }

        public GreetingBuilder(IDataService dataService)
        {
            _dataService = dataService;
        }

        public string Build()
        {
            return "hello, world!";
        }
        
        public string Build(string name)
        {
            return "hello, " + name + "!";
        }

        public string Build(string name, int age)
        {
            return $"{_dataService.GetMessageBasedOnAge(age)}, {name}!";
        }
    }
}
