namespace ACME.Domain
{
    public class GreetingBuilder
    {
        public string Build()
        {
            return "hello, world!";
        }
        
        public string Build(string name)
        {
            return "hello, " + name + "!";
        }
    }
}
