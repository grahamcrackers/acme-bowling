using System;
using ACME.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

[TestClass]
public class StubbingTests
{
    [TestMethod]
    public void should_build_a_greeting_based_on_age()
    {
        var mock = new Mock<IDataService>();

        mock.Setup(ds => ds.GetMessageBasedOnAge(45)).Returns("Whazzup");

        GreetingBuilder gb = new GreetingBuilder(mock.Object);

        string message = gb.Build("Joe", 45);

        Assert.AreEqual("Whazzup, Joe!", message);
    }

}