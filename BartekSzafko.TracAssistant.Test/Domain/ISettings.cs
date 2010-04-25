using System;
namespace BartekSzafko.TracAssistant.Test.Domain
{
    public interface ISettings
    {
        AuthenticationTypeEnum AuthenticationType { get; set; }
        string Password { get; set; }
        Uri TracUrl { get; set; }
        string Username { get; set; }
    }
}
