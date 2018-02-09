using ACME.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACME.Tests.Isolated.Core
{
    [TestClass]
    public class GreetingBuilderTests
    {
        [TestMethod]
        public void can_build_a_default_message()
        {
            GreetingBuilder sut = new GreetingBuilder();

            string message = sut.Build();

            Assert.AreEqual("hello, world!", message);
        }

        [TestMethod]
        public void can_build_message_with_name()
        {
            GreetingBuilder sut = new GreetingBuilder();

            string message = sut.Build("graham");

            Assert.AreEqual("hello, graham!", message);
        }
    }
}
