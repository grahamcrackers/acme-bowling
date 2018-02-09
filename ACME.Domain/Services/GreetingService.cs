using ACME.Domain;
using System;

public class GreetingService
{
    private readonly IEmailService _emailService;

    public GreetingService(IEmailService emailService)
    {
        _emailService = emailService;
    }


    public void SendEmail(string name, string email)
    {
        var greetingBuilder = new GreetingBuilder();

        _emailService.Send(email, greetingBuilder.Build(name));
    }
}