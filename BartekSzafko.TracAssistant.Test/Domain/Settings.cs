using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BartekSzafko.TracAssistant.Test.Domain
{
    public enum AuthenticationTypeEnum
    {
        Basic,
        Ntlm
    }

    public class Settings : BartekSzafko.TracAssistant.Test.Domain.ISettings
    {
        public Uri TracUrl { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }        
        public AuthenticationTypeEnum AuthenticationType { get; set; }
    }
}
