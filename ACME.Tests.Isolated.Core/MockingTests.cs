using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public class MockingTests
{
    [TestMethod]
    public void should_send_an_email()
    {
        var mockEmailService = new Mock<IEmailService>();

        GreetingService sut = new GreetingService(mockEmailService.Object);

        sut.SendEmail("joe", "e@m.com");

        mockEmailService.Verify(es => es.Send("e@m.com", "hello, joe!"));
    }

    public void should_save_a_user_score()
    {

    }
}